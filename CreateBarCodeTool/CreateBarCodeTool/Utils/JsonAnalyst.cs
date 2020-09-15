using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreateBarCodeTool.Utils {
    class JsonAnalyst {
        private string posInfo;
        private JObject tradeAllInfo;

        public JsonAnalyst(string posInfo) {
            this.posInfo = posInfo;
            this.tradeAllInfo = (JObject)JsonConvert.DeserializeObject(this.posInfo);
        }

        public string GetFirstLevelValue(string paraName) {
            JToken value = this.tradeAllInfo.GetValue(paraName);
            string strInfo = null;
            if (value != null && this.tradeAllInfo.Property(paraName) != null) {
                strInfo = this.tradeAllInfo.GetValue(paraName).ToString();
                strInfo = strInfo.Replace("\r\n", "").Replace("\t", "");
            }
            return strInfo;
        }

        public string GetSecondLevelValue(string firstLevelPara, string secondLevelPara) {
            string secondJsonLevel = "";
            string strFirstJsonLevel = this.tradeAllInfo.GetValue(firstLevelPara).ToString();
            if (strFirstJsonLevel != null) {
                JObject fistJsonLevel = (JObject)JsonConvert.DeserializeObject(strFirstJsonLevel);
                if (fistJsonLevel.Property(secondLevelPara) != null) {
                    secondJsonLevel = fistJsonLevel.GetValue(secondLevelPara).ToString();
                }
            }
            return secondJsonLevel;
        }

        public string GetSecondLevelValueFromArray(string firstLevelPara, string secondLevelPara, int index) {
            string secondJsonLevel = "";
            string strFirstJsonLevel = this.tradeAllInfo.GetValue(firstLevelPara).ToString();
            if (strFirstJsonLevel != null) {
                JArray fistJsonLevel = (JArray)JsonConvert.DeserializeObject(strFirstJsonLevel);
                secondJsonLevel = ((JObject)fistJsonLevel[index]).GetValue(secondLevelPara).ToString();
            }
            return secondJsonLevel;
        }

        public string GetThirdLevelValue(string firstLevelPara, string secondLevelPara, string thirdLevelPara) {
            string strThirdJsonValue = "";
            string strFirstJsonLevel = this.tradeAllInfo.GetValue(firstLevelPara).ToString();
            if (strFirstJsonLevel != null) {
                JObject fistJsonLevel = (JObject)JsonConvert.DeserializeObject(strFirstJsonLevel);
                string strSecondJsonValue = fistJsonLevel.GetValue(secondLevelPara).ToString();
                if (strSecondJsonValue != null) {
                    JObject secondJsonLevel = (JObject)JsonConvert.DeserializeObject(strSecondJsonValue);
                    if (secondJsonLevel.Property(thirdLevelPara) != null) {
                        strThirdJsonValue = secondJsonLevel.GetValue(thirdLevelPara).ToString();
                    }
                }
            }

            return strThirdJsonValue;
        }

        public string GetFourthLevelValue(string firstLevelPara, string secondLevelPara, string thirdLevelPara, string fourthLevelPara) {
            string strFirstJsonLevel = this.tradeAllInfo.GetValue(firstLevelPara).ToString();
            string strFouthJsonValue = "";
            if (strFirstJsonLevel != null) {
                JObject fistJsonLevel = (JObject)JsonConvert.DeserializeObject(strFirstJsonLevel);
                string strSecondJsonValue = fistJsonLevel.GetValue(secondLevelPara).ToString();
                if (strSecondJsonValue != null) {
                    JObject secondJsonLevel = (JObject)JsonConvert.DeserializeObject(strSecondJsonValue);
                    string strThirdJsonValue = secondJsonLevel.GetValue(thirdLevelPara).ToString();
                    if (strThirdJsonValue.Length > 0) {
                        JObject thirdJsonValue = (JObject)JsonConvert.DeserializeObject(strThirdJsonValue);
                        if (thirdJsonValue.Property(fourthLevelPara) != null) {
                            strFouthJsonValue = thirdJsonValue.GetValue(fourthLevelPara).ToString();
                        }
                    }
                }
            }
            return strFouthJsonValue;
        }

        public static implicit operator string(JsonAnalyst v) {
            throw new NotImplementedException();
        }
    }
}
