using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IOTBox_desktop_App
{

    public partial class Form1 : Form
    {
        public MqttClient mqtt_Client;
        private List<DataPoint> temp_data = new List<DataPoint>();
        private List<DataPoint> humidity_data = new List<DataPoint>();
        private List<DataPoint> gas_data = new List<DataPoint>();



        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
             chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[1].XValueType = ChartValueType.DateTime;

            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart2.Series[0].ChartType = SeriesChartType.Spline;
                chart2.Series[0].XValueType = ChartValueType.DateTime;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            string receivedMessage = Encoding.UTF8.GetString(e.Message);
            string topic= e.Topic;
            DateTime now = DateTime.Now.AddSeconds(1);
            


            this.Invoke((MethodInvoker)delegate
            {
            listBox1.Items.Add(receivedMessage + Environment.NewLine);
                if (topic=="temperature")
                {
                    temp_data.Add(new DataPoint(now.ToOADate(), double.Parse(receivedMessage)));
                    UpdateChart();
                    temp_lbl.Text = receivedMessage;
                }
                else if (topic == "humidity")
                {
                    humidity_data.Add(new DataPoint(now.ToOADate(), double.Parse(receivedMessage)));
                    UpdateChart();
                   hum_lbl.Text = receivedMessage;

                }
                else if (topic == "gas")
                {
                    gas_data.Add(new DataPoint(now.ToOADate(), double.Parse(receivedMessage)));
                    UpdateChart();
                    gas_lbl.Text = receivedMessage;

                }



            });

        }


        private void UpdateChart()
        {
            // Limit the number of data points to the latest 10 readings
            var latestDataPoints = temp_data.Count > 10 ? temp_data.GetRange(temp_data.Count - 5,5) : temp_data;
            var latestHumidityDataPoints = humidity_data.Count > 10 ? humidity_data.GetRange(humidity_data.Count - 5, 5) : humidity_data;
            var latestGasDataPoints = gas_data.Count > 10 ? gas_data.GetRange(gas_data.Count - 10, 10) : gas_data;



            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart2.Series[0].Points.Clear();

            foreach (var point in latestGasDataPoints)
            {
                chart2.Series[0].Points.Add(point);
            }


            foreach (var point in latestDataPoints)
            {
                chart1.Series[0].Points.Add(point);
            }
            foreach (var point in latestHumidityDataPoints)
            {
                chart1.Series[1].Points.Add(point);
            }

            // Set the X-axis range to show the latest 10 readings
            if (temp_data.Count > 0)
            {
                chart1.ChartAreas[0].AxisX.Minimum = latestDataPoints[0].XValue;
                chart1.ChartAreas[0].AxisX.Maximum = latestDataPoints[latestDataPoints.Count - 1].XValue;
            }
            if (humidity_data.Count > 0)
            {
                chart1.ChartAreas[0].AxisX.Minimum = latestHumidityDataPoints[0].XValue;
                chart1.ChartAreas[0].AxisX.Maximum = latestHumidityDataPoints[latestHumidityDataPoints.Count - 1].XValue;
            }
            if (gas_data.Count > 0)
            {
                chart2.ChartAreas[0].AxisX.Minimum = latestGasDataPoints[0].XValue;
                chart2.ChartAreas[0].AxisX.Maximum = latestGasDataPoints[latestGasDataPoints.Count - 1].XValue;
            }

        }

        private void txtReceivedMessages_TextChanged(object sender, EventArgs e)
        {

        }


    

        private void button3_Click(object sender, EventArgs e)
        {
            string topic = "test/topic";
            string message = txtMessageToSend.Text;
            if (listBox1.Items.Count > 5)
            {
                // Remove the oldest item (the one at index 0)
                listBox1.Items.RemoveAt(0);
            }

            // Ensure the newest message is visible
            listBox1.TopIndex = listBox1.Items.Count - 1;

            // Publish a message
            mqtt_Client.Publish(topic, Encoding.UTF8.GetBytes(message));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (mqtt_Client != null && mqtt_Client.IsConnected)
            {
                mqtt_Client.Disconnect();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string brokerAddress = textBox1.Text;
            int brokerPort = 8883; // Default SSL port for MQTT
           
            string[] topic = new string[] { "gas", "temperature", "test/topic", "humidity" };

            string clientId = Guid.NewGuid().ToString();

            // Initialize MQTT client with SSL
            mqtt_Client = new MqttClient(brokerAddress, brokerPort, true, MqttSslProtocols.TLSv1_2, null, null);

            // Register to message received event
            mqtt_Client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

            // Connect to the broker
            mqtt_Client.Connect(clientId, uname_txt.Text, pw_txt.Text);

            // Subscribe to the topic
            //mqtt_Client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            //mqtt_Client.Subscribe(new string[] { gas_rd }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            for (int i = 0; i < topic.Length; i++)
            {
                mqtt_Client.Subscribe(new string[] { topic[i] }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            }
           


            MessageBox.Show("Connected to broker!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("DO_1", Encoding.UTF8.GetBytes("0"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("DO_1", Encoding.UTF8.GetBytes("1"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("ir_control", Encoding.UTF8.GetBytes(""));

        }

        private void button7_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("DO_2", Encoding.UTF8.GetBytes("0"));

        }

        private void button10_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("DO_3", Encoding.UTF8.GetBytes("0"));

        }

        private void button12_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("DO_4", Encoding.UTF8.GetBytes("0"));

        }

        private void button8_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("DO_2", Encoding.UTF8.GetBytes("1"));

        }

        private void button9_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("DO_3", Encoding.UTF8.GetBytes("1"));

        }

        private void button11_Click(object sender, EventArgs e)
        {
            mqtt_Client.Publish("DO_4", Encoding.UTF8.GetBytes("1"));

        }

        private void uname_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}