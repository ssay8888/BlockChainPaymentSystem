using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainPaymentSystem.Constants.CultureCommon
{
    public class KeyPad
    {
        public string XPath { get; set; }
        public string Alt { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xPath">xPath 경로</param>
        /// <param name="alt">키 이름</param>
        public KeyPad(string xPath, string alt, int x, int y)
        {
            XPath = xPath;
            Alt = ChangeAlt(alt);
            X = x;
            Y = y;
        }

        private static string ChangeAlt(string oldAlt)
        {
            string newAlt;
            switch (oldAlt)
            {
                case "어금기호":
                    newAlt = "`";
                    break;
                case "물결표시":
                    newAlt = "~";
                    break;
                case "느낌표":
                    newAlt = "~";
                    break;
                case "골뱅이":
                    newAlt = "@";
                    break;
                case "샾":
                    newAlt = "#";
                    break;
                case "달러기호":
                    newAlt = "$";
                    break;
                case "퍼센트":
                    newAlt = "%";
                    break;
                case "꺽쇠":
                    newAlt = "^";
                    break;
                case "엠퍼샌드":
                    newAlt = "&";
                    break;
                case "*":
                    newAlt = "*";
                    break;
                case "왼쪽괄호":
                    newAlt = "(";
                    break;
                case "오른쪽괄호":
                    newAlt = ")";
                    break;
                case "빼기":
                    newAlt = "-";
                    break;
                case "밑줄":
                    newAlt = "_";
                    break;
                case "등호":
                    newAlt = "=";
                    break;
                case "더하기":
                    newAlt = "+";
                    break;
                case "곱하기":
                    newAlt = "*";
                    break;
                case "왼쪽대괄호":
                    newAlt = "[";
                    break;
                case "오른쪽대괄호":
                    newAlt = "]";
                    break;
                case "왼쪽중괄호":
                    newAlt = "{";
                    break;
                case "오른쪽중괄호":
                    newAlt = "}";
                    break;
                case "역슬래시":
                    newAlt = "\\";
                    break;
                case "수직막대":
                    newAlt = "|";
                    break;
                case "세미콜론":
                    newAlt = ";";
                    break;
                case "콜론":
                    newAlt = ":";
                    break;
                case "슬래시":
                    newAlt = "/";
                    break;
                case "물음표":
                    newAlt = "?";
                    break;
                case "쉼표":
                    newAlt = ",";
                    break;
                case "왼쪽꺽쇠괄호":
                    newAlt = "<";
                    break;
                case "마침표":
                    newAlt = ".";
                    break;
                case "오른쪽꺽쇠괄호":
                    newAlt = ">";
                    break;
                case "작은따옴표":
                    newAlt = "'";
                    break;
                case "따옴표":
                    newAlt = "\"";
                    break;
                default:
                    newAlt = oldAlt;
                    break;
            }
            return newAlt;
        }

    }
}
