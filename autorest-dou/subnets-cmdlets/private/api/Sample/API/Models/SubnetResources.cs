namespace Sample.API.Models
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>Subnet creation/modification spec.</summary>
    public partial class SubnetResources : Sample.API.Models.ISubnetResources, Microsoft.Rest.ClientRuntime.IValidates
    {
        /// <summary>Backing field for IpConfig property</summary>
        private Sample.API.Models.IIpConfig _ipConfig;

        /// <summary>IP config.</summary>
        public Sample.API.Models.IIpConfig IpConfig
        {
            get
            {
                return this._ipConfig;
            }
            set
            {
                this._ipConfig = value;
            }
        }
        /// <summary>Backing field for NetworkFunctionChainReference property</summary>
        private Sample.API.Models.INetworkFunctionChainReference _networkFunctionChainReference;

        /// <summary>The reference to a network_function_chain</summary>
        public Sample.API.Models.INetworkFunctionChainReference NetworkFunctionChainReference
        {
            get
            {
                return this._networkFunctionChainReference;
            }
            set
            {
                this._networkFunctionChainReference = value;
            }
        }
        /// <summary>Backing field for SubnetType property</summary>
        private string _subnetType;

        public string SubnetType
        {
            get
            {
                return this._subnetType;
            }
            set
            {
                this._subnetType = value;
            }
        }
        /// <summary>Backing field for VlanId property</summary>
        private int? _vlanId;

        public int? VlanId
        {
            get
            {
                return this._vlanId;
            }
            set
            {
                this._vlanId = value;
            }
        }
        /// <summary>Backing field for VswitchName property</summary>
        private string _vswitchName;

        public string VswitchName
        {
            get
            {
                return this._vswitchName;
            }
            set
            {
                this._vswitchName = value;
            }
        }
        /// <summary>Creates an new <see cref="SubnetResources" /> instance.</summary>
        public SubnetResources()
        {
        }
        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Rest.ClientRuntime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async System.Threading.Tasks.Task Validate(Microsoft.Rest.ClientRuntime.IEventListener eventListener)
        {
            await eventListener.AssertObjectIsValid(nameof(IpConfig), IpConfig);
            await eventListener.AssertObjectIsValid(nameof(NetworkFunctionChainReference), NetworkFunctionChainReference);
            await eventListener.AssertNotNull(nameof(SubnetType),SubnetType);
            await eventListener.AssertMaximumLength(nameof(VswitchName),VswitchName,64);
        }
    }
    /// Subnet creation/modification spec.
    public partial interface ISubnetResources : Microsoft.Rest.ClientRuntime.IJsonSerializable {
        Sample.API.Models.IIpConfig IpConfig { get; set; }
        Sample.API.Models.INetworkFunctionChainReference NetworkFunctionChainReference { get; set; }
        string SubnetType { get; set; }
        int? VlanId { get; set; }
        string VswitchName { get; set; }
    }
}