using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace Richasy.LocaleString.UWP
{
    public class LocaleHelper
    {
        internal static ResourceLoader TipResourceLoader;
        internal static ResourceLoader ControlsResourceLoader;
        internal static ResourceLoader OtherResourceLoader;
        private static LocaleConfig _config;

        /// <summary>
        /// 初始化帮助类
        /// </summary>
        /// <param name="config"></param>
        public void Load(LocaleConfig config)
        {
            if (config == null)
                config = LocaleConfig.Default;
            _config = config;
            Refresh();
        }

        /// <summary>
        /// 刷新帮助类
        /// </summary>
        public void Refresh()
        {
            if (_config == null)
                throw new Exception("Need load first.");

            try
            {
                TipResourceLoader = ResourceLoader.GetForCurrentView(_config.TipFileName);
            }
            catch (Exception)
            {}
            try
            {
                ControlsResourceLoader = ResourceLoader.GetForCurrentView(_config.ControlsFileName);
            }
            catch (Exception)
            {}
            try
            {
                OtherResourceLoader = ResourceLoader.GetForCurrentView(_config.OtherFileName);
            }
            catch (Exception)
            {}
        }

        /// <summary>
        /// 获取指定字符串
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetString(string key)
        {
            if (_config == null)
                throw new Exception("Need load first.");

            string result = string.Empty;

            if (key.Contains(_config.TipPrefix, StringComparison.OrdinalIgnoreCase))
            {
                result = TipResourceLoader.GetString(key);
            } 
            else if (key.Contains(_config.ControlsPrefix, StringComparison.OrdinalIgnoreCase))
            {
                result = ControlsResourceLoader.GetString(key);
            }  
            else if (key.Contains(_config.OtherPrefix, StringComparison.OrdinalIgnoreCase))
            {
                result = OtherResourceLoader.GetString(key);
            } 
            else
                throw new KeyNotFoundException("Invalid key");

            return result;
        }

        /// <summary>
        /// 获取指定字符串
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="property">属性</param>
        /// <returns></returns>
        public string GetString(string key,string property)
        {
            string name = $"{key}/{property}";
            return GetString(name);
        }

        /// <summary>
        /// 获取指定字符串
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetString(Enum key)
        {
            return GetString(key.ToString());
        }

        /// <summary>
        /// 获取指定字符串
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="property">属性</param>
        /// <returns></returns>
        public string GetString(Enum key, string property)
        {
            string name = $"{key}/{property}";
            return GetString(name);
        }
    }
}
