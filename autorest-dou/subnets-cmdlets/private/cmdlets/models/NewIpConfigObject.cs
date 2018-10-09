namespace Sample.API.ModelCmdlets
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>Cmdlet to create an in-memory instance of the <see cref="IpConfig" /> object.</summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"IpConfigObject")]
    [System.Management.Automation.OutputType(typeof(Sample.API.Models.IIpConfig))]
    public class NewIpConfigObject : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="IpConfig" /></summary>
        private Sample.API.Models.IIpConfig _ipConfig = new Sample.API.Models.IpConfig();
        /// <summary>Fully qualified domain name.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Fully qualified domain name.")]
        public string AddressFqdn
        {
            set
            {
                _ipConfig.DhcpServerAddress = _ipConfig.DhcpServerAddress ?? new Sample.API.Models.Address();
                _ipConfig.DhcpServerAddress.Fqdn = value;
            }
        }
        /// <summary>IPV4 address.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "IPV4 address.")]
        public string AddressIp
        {
            set
            {
                _ipConfig.DhcpServerAddress = _ipConfig.DhcpServerAddress ?? new Sample.API.Models.Address();
                _ipConfig.DhcpServerAddress.Ip = value;
            }
        }
        /// <summary>IPV6 address.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "IPV6 address.")]
        public string AddressIpv6
        {
            set
            {
                _ipConfig.DhcpServerAddress = _ipConfig.DhcpServerAddress ?? new Sample.API.Models.Address();
                _ipConfig.DhcpServerAddress.Ipv6 = value;
            }
        }
        /// <summary>Port Number</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Port Number")]
        public int AddressPort
        {
            set
            {
                _ipConfig.DhcpServerAddress = _ipConfig.DhcpServerAddress ?? new Sample.API.Models.Address();
                _ipConfig.DhcpServerAddress.Port = value;
            }
        }
        /// <summary>Default gateway IP address.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Default gateway IP address.")]
        public string DefaultGatewayIp
        {
            set
            {
                _ipConfig.DefaultGatewayIp = value;
            }
        }
        /// <summary>Spec for defining DHCP options.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Spec for defining DHCP options.")]
        public Sample.API.Models.IDhcpOptions DhcpOptions
        {
            set
            {
                _ipConfig.DhcpOptions = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public Sample.API.Models.IIpPool[] PoolList
        {
            set
            {
                _ipConfig.PoolList = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public int PrefixLength
        {
            set
            {
                _ipConfig.PrefixLength = value;
            }
        }
        /// <summary>Subnet IP address.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Subnet IP address.")]
        public string SubnetIp
        {
            set
            {
                _ipConfig.SubnetIp = value;
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            WriteObject(_ipConfig);
        }
    }
}