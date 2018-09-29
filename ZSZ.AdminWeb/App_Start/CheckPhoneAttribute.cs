using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZSZ.AdminWeb.App_Start
{
    public class ChinaPhoneAttribute : ValidationAttribute
    {
       
            public ChinaPhoneAttribute()
            {
                this.ErrorMessage = "电话号码必须是固话或者手机，固话要是3-4位区号开头，手机必须以13、15、18、17开头";
            }
            //注意，不要override ValidationResult IsValid(object value, ValidationContext validationContext)
            public override bool IsValid(object value)
            {
                if (value is string)
                {
                    string s = (string)value;

                    if (s.Length == 11)//手机号
                    {
                        if (s.StartsWith("13") || s.StartsWith("15") || s.StartsWith("17") || s.StartsWith("18"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (s.Contains("-"))//固话
                    {
                        //010,021 0755 0531
                        string[] strs = s.Split('-');
                        if (strs[0].Length == 3 || strs[0].Length == 4)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
     
    }
}