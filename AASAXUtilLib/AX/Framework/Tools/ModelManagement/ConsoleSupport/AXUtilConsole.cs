using Microsoft.Dynamics.AX.Framework.Tools.ModelManagement.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Microsoft.Dynamics.AX.Framework.Tools.ModelManagement.ConsoleSupport
{
    public class AXUtilConsole
    {
        private AxUtilConfiguration config = new AxUtilConfiguration();
        private const int ExitOK = 0;
        private const int ExitError = -1;
        private AXUtilConsoleBaseContext context;
        private AXUtilConsole.RunUtilHandle runUtil;
        private string utilMode;

        public AXUtilConsole(AXUtilConsoleBaseContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            this.context = context;
        }

        internal static bool CheckParameter(
          IList commandSwitches,
          ref int countOfParameter,
          ref ParameterInfo parameterInfo,
          AxUtilContext utilContext)
        {
            bool flag = false;
            AXUtilConsole.ParseCommandParameter(commandSwitches, ref parameterInfo);
            if (parameterInfo.Present)
            {
                if (!string.IsNullOrEmpty(parameterInfo.Value))
                {
                    flag = true;
                    ++countOfParameter;
                }
                else if (parameterInfo.Optional && (parameterInfo.RequiresValue == ParameterValue.NonRequired || parameterInfo.RequiresValue == ParameterValue.Optional))
                {
                    flag = true;
                    ++countOfParameter;
                }
                else
                    utilContext.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.CommandSwitchMissingValue, (object)parameterInfo.Name.ToUpperInvariant()));
            }
            else if (parameterInfo.Optional)
                flag = true;
            else
                utilContext.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.CommandSwitchMissing, (object)parameterInfo.Name.ToUpperInvariant()));
            return flag;
        }

        internal bool CheckParameter(
          IList commandSwitches,
          ref int countOfParameter,
          ref ParameterInfo parameterInfo)
        {
            return AXUtilConsole.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo, (AxUtilContext)this.context);
        }

        private static bool IsCommandSwitch(string command)
        {
            if (string.IsNullOrEmpty(command))
                return false;
            if (command[0] != '/' && command[0] != '-')
                return command[0] == '@';
            return true;
        }

        private static string GetCommandSwitch(string command)
        {
            if (command[0] != '@')
                return command.Remove(0, 1);
            return command;
        }

        private static bool IsHelpCommandSwitch(string command)
        {
            if (!AXUtilConsole.IsCommandSwitch(command))
                return false;
            string commandSwitch = AXUtilConsole.GetCommandSwitch(command);
            if (string.Compare(commandSwitch, "?", StringComparison.OrdinalIgnoreCase) != 0 && string.Compare(commandSwitch, "H", StringComparison.OrdinalIgnoreCase) != 0)
                return string.Compare(commandSwitch, "HELP", StringComparison.OrdinalIgnoreCase) == 0;
            return true;
        }

        private static void ParseCommandParameter(IList commandSwitches, ref ParameterInfo info)
        {
            foreach (string commandSwitch in (IEnumerable)commandSwitches)
            {
                AXUtilConsole.GetParameterValue(commandSwitch, ref info);
                if (info.Present)
                    break;
            }
        }

        private static void GetParameterValue(string command, ref ParameterInfo parameter)
        {
            string str = parameter.Name + ":";
            if (!command.StartsWith(str, StringComparison.OrdinalIgnoreCase))
                return;
            parameter.Value = command.Substring(str.Length);
            parameter.Present = true;
        }

        private bool RunUtil_Genlicense(IList commandSwitches)
        {
            int countOfParameter = 0;
            LicenseInfo licenseInfo = new LicenseInfo();
            if (!this.CheckParameter_License(commandSwitches, ref countOfParameter, ref licenseInfo))
                return false;
            this.config.LicenseInfo = licenseInfo;
            return new AxUtil((AxUtilContext)this.context, this.config).GenerateLicense();
        }

        public int Run(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));
            if (args.Length == 0)
            {
                this.context.DisplayHelp();
                return 0;
            }
            this.utilMode = args[0].Trim();
            if (AXUtilConsole.IsHelpCommandSwitch(this.utilMode))
            {
                this.context.DisplayHelp();
                return 0;
            }
            if (!this.ParseCommand(this.utilMode))
            {
                this.context.DisplayCopyright();
                if (string.IsNullOrEmpty(this.utilMode))
                    this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.EmptyCommandError));
                else
                    this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.UnknownCommandOrCommandSwitch, (object)this.utilMode));
                return -1;
            }
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            for (int index = 1; index < args.Length; ++index)
            {
                string command = args[index].Trim();
                if (command.Length == 0)
                    this.context.ReportWarning(Resources.EmptyCommandSwitchIgnored);
                else if (AXUtilConsole.IsCommandSwitch(command))
                {
                    string commandSwitch = AXUtilConsole.GetCommandSwitch(command);
                    if (AXUtilConsole.IsHelpCommandSwitch(commandSwitch))
                    {
                        this.context.DisplayHelp();
                        return 0;
                    }
                    bool flag = false;
                    if (string.Compare(commandSwitch, string.Empty, StringComparison.OrdinalIgnoreCase) == 0)
                        this.context.ReportWarning(Resources.EmptyCommandSwitchIgnored);
                    else
                        flag = true;
                    if (flag)
                    {
                        string upperInvariant = commandSwitch.ToUpperInvariant();
                        if (!dictionary.ContainsKey(upperInvariant))
                            dictionary.Add(upperInvariant, commandSwitch);
                    }
                }
                else
                {
                    this.context.ReportError(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Resources.UnknownCommandOrCommandSwitch, (object)command));
                    return -1;
                }
            }
            if (this.runUtil != null)
            {
                try
                {
                    return this.runUtil((IList)new List<string>((IEnumerable<string>)dictionary.Values)) ? 0 : -1;
                }
                catch (Exception ex)
                {
                    this.context.ReportError(ex.Message);
                }
            }
            return -1;
        }

        private bool ParseCommand(string commandParameter)
        {
            if (commandParameter.ToUpperInvariant() == "GENLICENSE")
                this.runUtil = new AXUtilConsole.RunUtilHandle(this.RunUtil_Genlicense);
            return this.runUtil != null;
        }

        private bool CheckParameter_License(
          IList commandSwitches,
          ref int countOfParameter,
          ref LicenseInfo licenseInfo)
        {
            ParameterInfo parameterInfo1 = new ParameterInfo(ParameterType.File, "FILE", false, ParameterValue.Required);
            ParameterInfo parameterInfo2 = new ParameterInfo(ParameterType.CertificatePath, "CERTIFICATEPATH", false, ParameterValue.Required);
            ParameterInfo parameterInfo3 = new ParameterInfo(ParameterType.LicenseCode, "LICENSECODE", false, ParameterValue.Required);
            ParameterInfo parameterInfo4 = new ParameterInfo(ParameterType.CompanyName, "CUSTOMER", false, ParameterValue.Required);
            ParameterInfo parameterInfo5 = new ParameterInfo(ParameterType.SerialNumber, "SERIALNUMBER", false, ParameterValue.Required);
            ParameterInfo parameterInfo6 = new ParameterInfo(ParameterType.ExpirationDate, "EXPIRATIONDATE", true, ParameterValue.Required);
            ParameterInfo parameterInfo7 = new ParameterInfo(ParameterType.UserCount, "USERCOUNT", true, ParameterValue.Required);
            ParameterInfo parameterInfo8 = new ParameterInfo(ParameterType.Password, "PASSWORD", false, ParameterValue.Required);
            if ((!this.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo1) || !this.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo2) || (!this.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo3) || !this.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo4)) || (!this.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo5) || !this.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo6) || !this.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo7)) ? 0 : (this.CheckParameter(commandSwitches, ref countOfParameter, ref parameterInfo8) ? 1 : 0)) == 0)
                return false;
            if (!File.Exists(parameterInfo2.Value))
            {
                this.context.ReportError(Resources.CertificateFileNotFound);
                return false;
            }
            DateTime? expirationDate = new DateTime?();
            if (parameterInfo6.Present)
            {
                try
                {
                    expirationDate = new DateTime?(DateTime.Parse(parameterInfo6.Value, (IFormatProvider)CultureInfo.CurrentCulture));
                }
                catch
                {
                    this.context.ReportError(Resources.InvalidLicenseExpirationDateFormat);
                    return false;
                }
            }
            int? userCount = new int?();
            if (parameterInfo7.Present)
            {
                int result;
                if (int.TryParse(parameterInfo7.Value, out result) && result >= 0)
                {
                    userCount = new int?(result);
                }
                else
                {
                    this.context.ReportError(Resources.InvalidUserCount);
                    return false;
                }
            }
            if (!new Regex("^[a-fA-F0-9]{8}(?:-[a-fA-F0-9]{4}){3}-[a-fA-F0-9]{12}$").IsMatch(parameterInfo5.Value))
            {
                this.context.ReportError(Resources.InvalidLicenseSerialNumber);
                return false;
            }
            licenseInfo = new LicenseInfo(parameterInfo1.Value, parameterInfo2.Value, parameterInfo3.Value, parameterInfo4.Value, parameterInfo5.Value, expirationDate, userCount, parameterInfo8.Value);
            return true;
        }

        private delegate bool RunUtilHandle(IList commandSwitches);
    }
}
