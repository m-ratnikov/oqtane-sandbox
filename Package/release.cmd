"..\..\oqtane.framework\oqtane.package\nuget.exe" pack QB.Customer.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
