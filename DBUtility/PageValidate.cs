using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace IndustryPlatform.Common
{
	/// <summary>
	/// 页面数据校验类
	/// 
	/// 2007.8
	/// </summary>
	public class PageValidate
	{
		private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegLetter = new Regex("^[a-zA-Z]+$");
		private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
		private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
		private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
		private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
		private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegDate = new Regex("^(\\d{4})(\\/|-)(\\d{1,2})(\\/|-)(\\d{1,2})$");

		public PageValidate()
		{
		}

		#region 数字字符串检查		
		
		/// <summary>
		/// 检查Request查询字符串的键值，是否是数字，最大长度限制
		/// </summary>
		/// <param name="req">Request</param>
		/// <param name="inputKey">Request的键值</param>
		/// <param name="maxLen">最大长度</param>
		/// <returns>返回Request查询字符串</returns>
		public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
		{
			string retVal = string.Empty;
			if(inputKey != null && inputKey != string.Empty)
			{
				retVal = req.QueryString[inputKey];
				if(null == retVal)
					retVal = req.Form[inputKey];
				if(null != retVal)
				{
					retVal = SqlText(retVal, maxLen);
					if(!IsNumber(retVal))
						retVal = string.Empty;
				}
			}
			if(retVal == null)
				retVal = string.Empty;
			return retVal;
		}
        /// <summary>
        /// 判断字符串是否大于指定长度
        /// </summary>
        /// <param name="inputData">要比较的字符串</param>
        /// <param name="imaxLen">指定长度</param>
        /// <returns></returns>
        public static bool IsLengther(string inputData, int imaxLen)
        {
            bool blFlag = false;

            int iLength = inputData.Length;

            if (iLength > imaxLen)
            {
                blFlag = true;
            }
            else
            {
                blFlag = false;
            }

            return blFlag;
        }
        /// <summary>
        /// 判断字符串是否小于指定长度
        /// </summary>
        /// <param name="inputData">要比较的字符串</param>
        /// <param name="imaxLen">指定长度</param>
        /// <returns></returns>
        public static bool IsShorter(string inputData, int iminLen)
        {
            bool blFlag = false;

            int iLength = inputData.Length;

            if (iLength < iminLen)
            {
                blFlag = true;
            }
            else
            {
                blFlag = false;
            }

            return blFlag;
        }
		/// <summary>
		/// 是否数字字符串
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsNumber(string inputData)
		{
			Match m = RegNumber.Match(inputData);
			return m.Success;
		}
        public static bool IsLetter(string inputData)
        {
            Match m = RegLetter.Match(inputData);
            return m.Success;
        }
		/// <summary>
		/// 是否数字字符串 可带正负号
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsNumberSign(string inputData)
		{
			Match m = RegNumberSign.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// 是否是浮点数
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsDecimal(string inputData)
		{
			Match m = RegDecimal.Match(inputData);
			return m.Success;
		}		
		/// <summary>
		/// 是否是浮点数 可带正负号
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsDecimalSign(string inputData)
		{
			Match m = RegDecimalSign.Match(inputData);
			return m.Success;
		}		

		#endregion

		#region 中文检测

		/// <summary>
		/// 检测是否有中文字符
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static bool IsHasCHZN(string inputData)
		{
			Match m = RegCHZN.Match(inputData);
			return m.Success;
		}	

		#endregion

		#region 邮件地址
		/// <summary>
		/// 是否是浮点数 可带正负号
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsEmail(string inputData)
		{
			Match m = RegEmail.Match(inputData);
			return m.Success;
		}		

		#endregion

        #region 日期
        /// <summary>
        /// 是否是日期格式
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDateTime(string inputData)
        {
            bool flag = false;
        
            string regex = @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))"; //日期部分
            regex += @"(\s(((0?[0-9])|([1][0-9])|([2][0-4]))\:([0-5]?[0-9])((\s)|(\:([0-5]?[0-9])))))?$"; //时间部分

            RegexOptions options = ((RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline) | RegexOptions.IgnoreCase);
            Regex reg = new Regex(regex, options);
            if (reg.IsMatch(inputData))
            {
                flag = true;
            }
            return flag;
        }
        public static bool IsDate(string inputData)
        {
            bool flag = false;

            string regex = @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))"; //日期部分
            

            RegexOptions options = ((RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline) | RegexOptions.IgnoreCase);
            Regex reg = new Regex(regex, options);
            if (reg.IsMatch(inputData))
            {
                flag = true;
            }
            return flag;
        }

        #endregion

        #region 其他

        /// <summary>
		/// 检查字符串最大长度，返回指定长度的串
		/// </summary>
		/// <param name="sqlInput">输入字符串</param>
		/// <param name="maxLength">最大长度</param>
		/// <returns></returns>			
		public static string SqlText(string sqlInput, int maxLength)
		{			
			if(sqlInput != null && sqlInput != string.Empty)
			{
				sqlInput = sqlInput.Trim();							
				if(sqlInput.Length > maxLength)//按最大长度截取字符串
					sqlInput = sqlInput.Substring(0, maxLength);
			}
			return sqlInput;
		}		
		/// <summary>
		/// 字符串编码
		/// </summary>
		/// <param name="inputData"></param>
		/// <returns></returns>
		public static string HtmlEncode(string inputData)
		{
			return HttpUtility.HtmlEncode(inputData);
		}
		/// <summary>
		/// 设置Label显示Encode的字符串
		/// </summary>
		/// <param name="lbl"></param>
		/// <param name="txtInput"></param>
		public static void SetLabel(Label lbl, string txtInput)
		{
			lbl.Text = HtmlEncode(txtInput);
		}
		public static void SetLabel(Label lbl, object inputObj)
		{
			SetLabel(lbl, inputObj.ToString());
		}		
		//字符串清理
		public static string InputText(string inputString, int maxLength) 
		{			
			StringBuilder retVal = new StringBuilder();

			// 检查是否为空
			if ((inputString != null) && (inputString != String.Empty)) 
			{
				inputString = inputString.Trim();
				
				//检查长度
				if (inputString.Length > maxLength)
					inputString = inputString.Substring(0, maxLength);
				
				//替换危险字符
				for (int i = 0; i < inputString.Length; i++) 
				{
					switch (inputString[i]) 
					{
						case '"':
							retVal.Append("&quot;");
							break;
						case '<':
							retVal.Append("&lt;");
							break;
						case '>':
							retVal.Append("&gt;");
							break;
						default:
							retVal.Append(inputString[i]);
							break;
					}
				}				
				retVal.Replace("'", " ");// 替换单引号
			}
			return retVal.ToString();
			
		}
		/// <summary>
		/// 转换成 HTML code
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>string</returns>
		public static string Encode(string str)
		{			
			str = str.Replace("&","&amp;");
			str = str.Replace("'","''");
			str = str.Replace("\"","&quot;");
			str = str.Replace(" ","&nbsp;");
			str = str.Replace("<","&lt;");
			str = str.Replace(">","&gt;");
			str = str.Replace("\n","<br>");
			return str;
		}
		/// <summary>
		///解析html成 普通文本
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>string</returns>
		public static string Decode(string str)
		{			
			str = str.Replace("<br>","\n");
			str = str.Replace("&gt;",">");
			str = str.Replace("&lt;","<");
			str = str.Replace("&nbsp;"," ");
			str = str.Replace("&quot;","\"");
			return str;
		}

		#endregion

		/// <summary>
		/// 将日期时间型转换成字符串
		/// </summary>
		/// <param name="datetime">时间字符串</param>
		/// <param name="IsDate">是否转换成日期类型</param>
		/// <returns></returns>
		#region 将日期时间型转换成字符串
		public static string GetDateorGetDateTime(string datetime, bool IsDate)
		{
			string str_date = datetime.Replace("/","-");
			string[] dtime = datetime.Split(' ');
			if (IsDate)
			{
				string[] arr = new string[3];
				arr = dtime[0].Split('-');

				if (arr[1].Length == 1)
				{
					arr[1] = arr[1].PadLeft(2, '0');
				}
				if (arr[2].Length == 1)
				{
					arr[2] = arr[2].PadLeft(2, '0');
				}
				str_date = arr[0] + "-" + arr[1] + "-" + arr[2];
			}
			else
			{
				#region 年月日
				string[] date = dtime[0].Split('-');
				string month = date[1].PadLeft(2, '0');
				string day = date[2].PadLeft(2, '0');
				#endregion

				#region 时分秒
				string[] datet = dtime[1].Split(':');
				string hour = datet[0].PadLeft(2, '0');
				string min = datet[1];
				string second = datet[2];
				#endregion


				str_date = date[0].ToString() + "-" + month + "-" + day + " " + hour + ":" + min + ":" + second;
			}
			return str_date;
		}
		#endregion

	}
}
