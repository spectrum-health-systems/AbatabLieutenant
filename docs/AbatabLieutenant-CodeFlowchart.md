<div align="center">

![Logo][AbatabLieutenantLogo]

# CODE FLOWCHART

</div>

<div align="center">

  ```mermaid
  graph TD

      AbatabLieutenant.exe([AbatabLieutenant.exe]) --> PassedArgumentCheck{"More than one argument passed <br> AND <br> argument is valid"}
      
      PassedArgumentCheck -- No --> DisplayHelp.cs(Display help <br> to console)
      DisplayHelp.cs --> ExitLtnt([Exit])

      PassedArgumentCheck -- Yes --> InitializeFramework(Initialize <br> Abatab Lieutenant <br>framework)
      InitializeFramework --> BackupCurrent(Backup <br>current deployment)
      BackupCurrent --> PrepareTarget(Prepare <br>deployment target)
      PrepareTarget --> DeployBranch(Deploy <br> requested branch)
      DeployBranch --> ExitLtnt
  ```
</div>

[AbatabLieutenantLogo]: ../../resources/images/logos/AbatabLieutenantLogo.png
