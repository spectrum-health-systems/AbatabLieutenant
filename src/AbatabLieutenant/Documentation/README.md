<div align="center">

![AbatabLogo](AbatabLieutenantLogo.png)

<br>

</div>

<!-- The HTML indentations have to stay this way to work. -->
<table>
<tr>
<td img src="RepositoryData/Asset/Image/Document/README/spacer.png" alt="blank-spacer" width="1000" height="1">

  ### CONTENTS
  [About](#about)  
  [Getting started](#getting-started)  
  [Using](#using)  
  [Logs](#logs)  
  [Additional information](#additional-information)  

</td>
</tr>
</table>

# About

[Abatab Lieutenant](https://github.com/spectrum-health-systems/AbatabLieutenant) is a deployment manager for Abatab.

By default, Abatab Lieutenant will only deploy branches to the Abatab instance available to UAT.

Deploying branches to the Abatab instance available to LIVE should be done manually.

# Configuration

## Local settings

Local configuration settings can be found in `AbatabLieutenant.json`.

# Using

## Deploying an Abatab branch.

To deploy a specific branch of Abatab, open a terminal and type `AbatabLieutenant.exe %BranchName%`.

### Valid Abatab branch names

The following are valid branch names:

* development
* main
* testing

# Logging

Abatab Lieutenant will display log information to the console, as well as a log file located in **LtntRoot\Logs\\**

# The Abatab Lieutenant process

If you are curious as to what Abatab Lieutenant does while it's working, you can check out this cool [flowchart](https://github.com/spectrum-health-systems/AbatabLieutenant/blob/main/docs/AbatabLieutenant-CodeFlowchart.md).

# Deploying an Abatab branch to the instance available to LIVE

By default, deploying Abatab branches to the instance available to LIVE must be done manually. This is by design, and ensures the Abatab instance available to LIVE is not impacted by testing development branches of Abatab.

Deploying an Abatab branch to the instance available to LIVE should be done when users are not in the system. Your options are:

1. Deploy after hours (e.g., 11PM on a Saturday) when users most likely won't be in the system
2. Deploy during Avatar scheduled maintenance
3. Disable all ScriptLink calls from within Avatar (very time consuming, don't do this)

Once you are ready to deploy:

1. Remove all files from `C:\AvatoolWebService\Abatab_LIVE`
2. Copy all files from `C:\AvatoolWebService\Abatab_UAT` to `C:\AvatoolWebService\Abatab_LIVE`
3. Make the necessary configuration setting changes in Web.config












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
