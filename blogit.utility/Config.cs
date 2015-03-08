using System;
using System.Configuration;
using System.Linq;

namespace BlogIT.Utility
{
    public static class Config
    {
        /// <summary>
        ///     Tell system which key name you wann to fetch
        /// </summary>
        public static string ConnStringName { set; get; }

        /// <summary>
        ///     Static class that access the app settings in the web.config file
        /// </summary>
        /// <summary>
        ///     Current BoardID -- default is 1.
        /// </summary>
        public static string BoardID
        {
            get { return GetConfigValueAsString("BoardID") ?? "1"; }
        }

        /// <summary>
        ///     Current CategoryID -- default is null.
        /// </summary>
        public static string CategoryID
        {
            get { return GetConfigValueAsString("CategoryID"); }
        }

        /// <summary>
        ///     Is Url Rewriting enabled? -- default is false.
        /// </summary>
        public static bool EnableURLRewriting
        {
            get { return GetConfigValueAsBool("EnableUrlRewriting", false); }
        }

        /// <summary>
        ///     Used for Url Rewriting -- default is null.
        /// </summary>
        public static string ForceScriptName
        {
            get { return GetConfigValueAsString("ForceScriptName"); }
        }

        /// <summary>
        ///     Used for Url Rewriting -- default is "default.aspx"
        /// </summary>
        public static string BaseScriptFile
        {
            get { return GetConfigValueAsString("BaseScriptFile") ?? "default.aspx"; }
        }

        /// <summary>
        ///     Gets FileRoot.
        /// </summary>
        public static string FileRoot
        {
            get { return GetConfigValueAsString("FileRoot") ?? String.Empty; }
        }

        /// <summary>
        ///     Gets AppRoot.
        /// </summary>
        public static string AppRoot
        {
            get { return GetConfigValueAsString("AppRoot") ?? String.Empty; }
        }

        /// <summary>
        ///     Gets User Profile Image Path
        /// </summary>
        public static string UserProfileImage
        {
            get { return GetConfigValueAsString("UserProfileImage") ?? "~/images/"; }
        }

        /// <summary>
        ///     Boolean to force uploads, and images, themes etc.. from a specific BoardID folder within BoardRoot
        ///     Example : true /false
        /// </summary>
        public static bool MultiBoardFolders
        {
            get { return GetConfigValueAsBool("MultiBoardFolders", false); }
        }


        /// <summary>
        ///     Gets ProviderKeyType.
        /// </summary>
        public static string ProviderKeyType
        {
            get { return GetConfigValueAsString("ProviderKeyType") ?? "System.Guid"; }
        }

        /// <summary>
        ///     Gets MembershipProvider.
        /// </summary>
        public static string MembershipProvider
        {
            get { return GetConfigValueAsString("MembershipProvider") ?? string.Empty; }
        }

        /// <summary>
        ///     Gets RoleProvider.
        /// </summary>
        public static string RoleProvider
        {
            get { return GetConfigValueAsString("RoleProvider") ?? string.Empty; }
        }

        public static string HomePage
        {
            get { return GetConfigValueAsString("HomePage") ?? string.Empty; }
        }

        /// <summary>
        ///     Display the default toolbar at the top -- default is "true"
        /// </summary>
        public static bool ShowToolBar
        {
            get { return GetConfigValueAsBool("ShowToolBar", true); }
        }

        /// <summary>
        ///     Diisplay the footer at the bottom of the page -- default is "true"
        /// </summary>
        public static bool ShowFooter
        {
            get { return GetConfigValueAsBool("ShowFooter", true); }
        }

        /// <summary>
        ///     Use an SSL connection for the SMTP server -- default is "false"
        /// </summary>
        public static bool UseSMTPSSL
        {
            get { return GetConfigValueAsBool("UseSMTPSSL", false); }
        }

        /// <summary>
        ///     Enable SSL generally false but for gmail it should be true
        /// </summary>
        public static bool EnableSsl
        {
            get { return GetConfigValueAsBool("EnableSsl", false); }
        }

        /// <summary>
        ///     Gets ConnectionString.
        /// </summary>
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString; }
        }

        /// <summary>
        ///     Gets SMTP server, default value is localhost
        /// </summary>
        public static string SmtpHost
        {
            get { return GetConfigValueAsString("smtpserver") ?? "localhost"; }
        }

        /// <summary>
        ///     Get From Mail ID
        /// </summary>
        public static string From
        {
            get { return GetConfigValueAsString("from") ?? "no-reply@mymail.com"; }
        }

        /// <summary>
        ///     Get Smtp Port
        /// </summary>
        public static Int32 SmtpPort
        {
            get { return GetConfigValueAsInt("port", 25); }
        }

        /// <summary>
        ///     Get Email From Name
        /// </summary>
        public static string FromName
        {
            get { return GetConfigValueAsString("fromName") ?? "System Mailer"; }
        }

        /// <summary>
        /// </summary>
        public static string WebSiteModeratorsList
        {
            get { return GetConfigValueAsString("WebSiteModeratorsList") ?? "webmaster@mymail.com"; }
        }

        /// <summary>
        /// </summary>
        public static string SMTPAuthenticationUserName
        {
            get
            {
                return GetConfigValueAsString("SMTPAuthenticationUserName") ?? "SMTPAuthenticationUserName@mymail.com";
            }
        }

        /// <summary>
        /// </summary>
        public static string SMTPAuthenticationPassword
        {
            get
            {
                return GetConfigValueAsString("SMTPAuthenticationPassword") ?? "SMTPAuthenticationPassword@mymail.com";
            }
        }

        /// <summary>
        ///     Get Password of your from mailid
        /// </summary>
        public static string FromPassword
        {
            get { return GetConfigValueAsString("password") ?? "password"; }
        }


        /// <summary>
        ///     Get Reply Status default ---- false
        /// </summary>
        public static bool IsReplyAsSender
        {
            get { return GetConfigValueAsBool("IsReplyAsSender", false); }
        }

        /// <summary>
        ///     Get Reply Emal address
        /// </summary>
        public static string ReplyEmail
        {
            get { return GetConfigValueAsString("ReplyEmail") ?? "noreply@mydomain.com"; }
        }

        /// <summary>
        ///     Get Replyname
        /// </summary>
        public static string ReplyName
        {
            get { return GetConfigValueAsString("ReplyName") ?? "Do Not reply"; }
        }

        /// <summary>
        ///     Get confimation whether new users allowed to register or not
        /// </summary>
        public static bool EnableRegistration
        {
            get { return GetConfigValueAsBool("EnableRegistration", true); }
        }

        /// <summary>
        ///     Enable Routing instead of Url-Rewritting
        /// </summary>
        public static bool EnableRouting
        {
            get { return GetConfigValueAsBool("EnableRouting", false); }
        }

        /// <summary>
        ///     Get Title Prefix for all Pages
        /// </summary>
        public static string TitlePrefix
        {
            get
            {
                return !string.IsNullOrEmpty(GetConfigValueAsString("TitlePrefix"))
                    ? GetConfigValueAsString("TitlePrefix")
                    : "BlogIt : ";
            }
        }

        /// <summary>
        ///     Get Site url
        /// </summary>
        public static string SiteUrl
        {
            get
            {
                return !string.IsNullOrEmpty(GetConfigValueAsString("SiteUrl"))
                    ? GetConfigValueAsString("SiteUrl")
                    : "http://blogit.com"; //this value needs to be changed
            }
        }

        #region Database Settings

        /// <summary>
        ///     Gets ConnectionStringName.
        /// </summary>
        public static string ConnectionStringName
        {
            get
            {
                return
                    GetConfigValueAsString(string.IsNullOrEmpty(ConnStringName)
                        ? "ConnectionStringname"
                        : ConnStringName) ?? "cn";
            }
        }

        /// <summary>
        ///     Gets DatabaseOwner.
        /// </summary>
        public static string DatabaseOwner
        {
            get { return GetConfigValueAsString("DatabaseOwner") ?? "dbo"; }
        }

        /// <summary>
        ///     Gets DatabaseObjectQualifier.
        /// </summary>
        public static string DatabaseObjectQualifier
        {
            get { return GetConfigValueAsString("DatabaseObjectQualifier") ?? ""; }
        }

        // Different data layers specific settings


        /// <summary>
        ///     Gets DatabaseEncoding.
        /// </summary>
        public static string DatabaseEncoding
        {
            get { return GetConfigValueAsString("DatabaseEncoding"); }
        }

        /// <summary>
        ///     Gets DatabaseCollation.
        /// </summary>
        public static string DatabaseCollation
        {
            get { return GetConfigValueAsString("DatabaseCollation"); }
        }

        /// <summary>
        ///     Gets SchemaName.
        /// </summary>
        public static string SchemaName
        {
            get { return GetConfigValueAsString("DatabaseSchemaName"); }
        }

        #endregion

        #region Fetching keys from Config file

        /// <summary>
        ///     The get config value as string.
        /// </summary>
        /// <param name="configKey">
        ///     The config key.
        /// </param>
        /// <returns>
        ///     The get config value as string.
        /// </returns>
        public static string GetConfigValueAsString(string configKey)
        {
            return (from key in ConfigurationManager.AppSettings.AllKeys
                where key.Equals(configKey, StringComparison.CurrentCultureIgnoreCase)
                select ConfigurationManager.AppSettings[key]).FirstOrDefault();
        }

        /// <summary>
        ///     The get config value as bool.
        /// </summary>
        /// <param name="configKey">
        ///     The config key.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        ///     The get config value as bool.
        /// </returns>
        public static bool GetConfigValueAsBool(string configKey, bool defaultValue)
        {
            string value = GetConfigValueAsString(configKey);

            if (!String.IsNullOrEmpty(value))
            {
                //return Convert.ToBoolean(value.ToLower());
                return CleanUtil.ToBool(value.ToLower());
            }

            return defaultValue;
        }

        /// <summary>
        ///     The get config value as Int.
        /// </summary>
        /// <param name="configKey">
        ///     The config key.
        /// </param>
        /// <param name="defaultValue">
        ///     The default value.
        /// </param>
        /// <returns>
        ///     The get config value as Int32.
        /// </returns>
        public static Int32 GetConfigValueAsInt(string configKey, Int32 defaultValue)
        {
            string value = GetConfigValueAsString(configKey);

            if (!String.IsNullOrEmpty(value))
            {
                //return Convert.ToBoolean(value.ToLower());
                return CleanUtil.ToInt(value.ToLower());
            }

            return defaultValue;
        }

        #endregion
    }
}