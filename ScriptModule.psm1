Function Add-Number($x , $y)
{
	$x + $y
}
Function Subtract-Numbers($x, $y)
{
	$x-$y
}
New-Alias -Name an -Value Add-Numbers
New-Alias -Name sn -Value Subtract-Numbers

#Export modules member
Export-ModuleMember -Function * -Alias *

