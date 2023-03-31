cd "./src"
msbuild -t:restore -p:RestorePackagesConfig=true
msbuild /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:PackageLocation="C:\Users\windows-vm-admin\packages"  /p:_PackageTempDir=C:\package /p:PackageTempRootDir=
Expand-Archive -Path "C:\Users\windows-vm-admin\packages\dummy-dot-net-framework-web-app.zip" -DestinationPath "C:\inetpub\sites\test" -Force
Reset-IISServerManager -Confirm:$False
Remove-IISSite -Name 'localhost' -Confirm:$False -ErrorAction SilentlyContinue
Reset-IISServerManager -Confirm:$False
New-IISSite -Name 'localhost' -PhysicalPath "C:\inetpub\sites\test\Content\C_C\package\" -BindingInformation "*:80:"
