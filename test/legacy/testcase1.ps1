#
# 1) Provision a new network
# 2) Create a new image
# 3) make a new VM from that image
# 4) Attach it to the network
#

# Start connection.
Import-Module -Force ./build/NtnxPoshSDK.dll
$ClusterIp = '10.7.255.141'
$Password = ConvertTo-SecureString 'Nutanix.123' -AsPlainText -Force
New-NtnxConnection -Server $ClusterIp -UserName admin -Password $Password `
  -AcceptInvalidSslCerts

# Get available clusters.
$Clusters = Get-Cluster
$Cluster = $Clusters[0]

# 1) Provision new network.
$Cluster # Print Cluster just for debug.
$Task = New-VirtualSwitch -Name vlan1 -VlanId 1 -Cluster $Cluster
$Task.Wait()
$Network = Get-VirtualSwitch -Name vlan1

# 2) Create a new image
$ImageUrl = 'http://earth.corp.nutanix.com/acro_images/automation/ahv_guest_os/DSK/centos73_vdisk.raw'
$ImageName = 'centos73'
New-Image -Name $ImageName -URL $ImageUrl -Description 'FROM SDK'
$Image = Get-Image -Name $ImageName

# 3) make a new VM from that image
# 4) attach it to the network
$Task = New-Vm -Name $TestVmName -ImageUuid $Image.Uuid -NetworkUuid $Network.Uuid
$Task.Wait()
$VM = Get-Vm -Name $TestVmName
