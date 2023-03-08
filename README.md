<div align="center">

[![Logo][Logo]][MainBranchUrl]

# A command line deployment utility for Abatab

![Status][Status]&nbsp;&nbsp;&nbsp;[![License][License]][LicenseUrl]&nbsp;&nbsp;&nbsp;![.NET][DotNet]&nbsp;&nbsp;&nbsp;![Release][Release]&nbsp;&nbsp;&nbsp;![Issues][Issues]&nbsp;&nbsp;&nbsp;![PullRequests][PullRequests]

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

Abatab Lieutenant is a simple utility that deploys repository branches of [Abatab][AbatabUrl] to the server where where Abatab is hosted.

Abatab Lieutenant is intended to be used with non-production installations of Abatab.

## Features

* Cross-platform
* Highly configurable via local configuration file

## Requirements

* [.Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) runtime
* Works best with respositories hosted on [GitHub](https://github.com/)

# Getting started

## Installing

Abatab Lieutenant is a portable application, so it doesn't need to be installed. All you need to do is:

1. Download the latest [release][ReleaseUrl], then...
2. Extract the .zip archive to a location on the server where Abatab is hosted

# Using

## Deploying to LIVE

By default, Abatab Lieutenant will only deploy Abatab branches to a UAT environment. This is by design, to ensure that LIVE environments are not modified in any way.

**It is recommended that you deploy Abatab to your production/LIVE environments manually.**

## Configuration and settings

The first time you execute Abatab Lieutenant, a default AbatabLieutenant.json, which contains all of the necessary settings for Abatab Lieutenant, will be created.

Assuming that you have installed Abatab per the instructions, you shouldn't need to modify any of the settings.

## Displaying help information

To display the help information, open a terminal and type:

    `$ AbatabLieutenant`

## Deploying an Abatab branch

To deploy a specific branch of Abatab, open a terminal and type:

    `$ AbatabLieutenant.exe %BranchName%`.

For example:

    `$ AbatabLieutenant.exe testing`

### Valid Abatab branches

The following Abatab branches are available for deployment via Abatab Lieutenant:

* development
* main
* testing

## Minimal Deployment Mode (experimental)

**THIS IS AN EXPERIMENTAL FEATURE, AND SHOULD NOT BE USED!**

By default, Abatab Lieutenant downloads the entire requested Abatab branch, which is not the most efficient way of doing things (but it works!).

By adding the `min` option, you can use the experimental "Minimal Deployment Mode", which only downloads the necessary files.

You can do this by opening a terminal and typing:

    `$ AbatabLieutenant.exe testing min`

# How it works/what it does

Abatab Lieutenant:

1. Downloads the latest *%BranchName%* branch of Abatab, as a .zip archive, to the "*C:\AbatabData\Lieutnant\Staging*\\" staging folder.
2. Extracts the contents of the .zip archive to "*C:\AbatabData\Lieutnant\Staging\\%BranchName%*\\" folder.
3. Copies the necessary web service files to "*C:\AbatabWebService\UAT*\\" (the Abatab web service deployment for UAT)
4. Copies everything in "*C:\AbatabData\Lieutnant\Staging\\%BranchName%\bin*\\" folder. to "*C:\AbatabWebService\UAT\bin\*\\"

# Logs

Abatab Lieutenant logs can be found here in *AbatabData\Lieutenant\Logs\\*.

# Additional information

Please see the [changelog][Changelog] for a history of changes, and the [roadmap][Roadmap] for any upcoming features/fixes.

***

<br>

<div align="center">

  ![LastCommit][LastCommit]&nbsp;&nbsp;&nbsp;![CodeSize][CodeSize]&nbsp;&nbsp;&nbsp;![LinesOfCode][LinesOfCode]&nbsp;&nbsp;&nbsp;![RepoFileCount][RepoFileCount]&nbsp;&nbsp;&nbsp;![RepoSize][RepoSize]
  <br>
  <br>

  Abatab Lieutenant is developed by [A Pretty Cool Program][APrettyCoolProgramUrl].

</div>

[DotNet]: https://img.shields.io/badge/.NET-6.0-blueviolet

[AbatabUrl]: https://github.com/spectrum-health-systems/Abatab
[MainBranchUrl]: README.md
[Logo]: ./resources/images/logos/AbatabLieutenantLogo_V4.png
[Status]: https://img.shields.io/badge/status-active-brightgreen?style=flat
[License]: https://img.shields.io/badge/license-apache%202.0-brightgreen?style=flat
[LicenseUrl]: https://www.apache.org/licenses/LICENSE-2.0
[Release]: https://img.shields.io/github/v/release/spectrum-health-systems/AbatabLieutenant?style=flat
[ReleaseUrl]: https://github.com/spectrum-health-systems/AbatabLieutenant/releases

[AbatabCommanderUrl]: https://github.com/spectrum-health-systems/AbatabCommander
[Changelog]: https://github.com/spectrum-health-systems/AbatabLieutenant/blob/main/docs/CHANGELOG.md
[Roadmap]: https://github.com/spectrum-health-systems/AbatabLieutenant/blob/main/docs/ROADMAP.md
[APrettyCoolProgramUrl]: https://github.com/APrettyCoolProgram

[AbatabBaseUrl]: https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/
[LtntRootNotes]: #ltntroot
[CustomBranchNotes]: #deploying-a-custom-branch-of-abatab

[CodeSize]: https://img.shields.io/github/languages/code-size/spectrum-health-systems/AbatabLieutenant
[LinesOfCode]: https://img.shields.io/tokei/lines/github/spectrum-health-systems/AbatabLieutenant
[RepoFileCount]: https://img.shields.io/github/directory-file-count/spectrum-health-systems/AbatabLieutenant
[RepoSize]: https://img.shields.io/github/repo-size/spectrum-health-systems/AbatabLieutenant
[AllReleases]: https://img.shields.io/github/downloads/spectrum-health-systems/AbatabLieutenant/total
[Issues]: https://img.shields.io/github/issues/spectrum-health-systems/AbatabLieutenant
[PullRequests]: https://img.shields.io/github/issues-pr/spectrum-health-systems/AbatabLieutenant
[LastCommit]: https://img.shields.io/github/last-commit/spectrum-health-systems/AbatabLieutenant
