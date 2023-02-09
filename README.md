<div align="center">

![Followers][GitHubFollowers] ![Forks][GitHubForks] ![Stars][GitHubStars] ![Watchers][GitHubWatchers]

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

***It is recommended that you deploy Abatab to your production/LIVE environments manually.***

Please see the [changelog][Changelog] for a history of changes, and the [roadmap][Roadmap] for any upcoming features/fixes.

## Features

* Cross-platform
* Configurable via local configuration file

## Requirements

* [.Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) runtime
* Works best with respositories hosted on [GitHub](https://github.com/)

# Getting started

## Installing

Abatab Lieutenant is a portable application, so it doesn't need to be installed. All you need to do is:

1. Download the latest [release][ReleaseUrl], then...
2. Uncompress the .zip file to a location on the server where Abatab is hosted

# Configuration

Before you use Abatab Lieutenant, it is recommended that you confirm that the default settings in **AbatabLieutenant.exe.config** are correct for your organization, and make any necessary modifications.

These are the default configuration settings:

| Setting           | Description                                                                                | Default |
| ----------------- | ------------------------------------------------------------------------------------------ | ------- |
| **LtntVersion** | The current version of Abatab Lieutenant | `3.0.0` |
| **LtntRoot** | All Abatab Lieutenant related data (see [notes][LtntRootNotes]) | `C:\AbatabData\Lieutenant` |
| **CustomBranch** | An optional branch outside of the standard deployment branches (see [notes][CustomBranchNotes]) | `<empty>` |
| **RepositoryUrl** | The base Abatab repository URL that is used to download branches | [Link][AbatabBaseUrl] |
| **AbatabDeploymentRoot** | The location where you want to Abatab Lieutenant to deploy an Abatab branch | `C:\Abatab\UAT`

## LtntRoot

The LtntRoot directory contains data the is required by Abatab Lieutentant, such as:

* Abatab Lieutenant logs
* Abatab branch downloads
* Deployment staging data  

## Custom branches

You can use the CustomBranch configuration setting to allow a custom branch to be deployed, and follows these rules:

* The CustomBranch name needs to be the `%filename%` part of `%filename%.zip`.
* There can only be one custom branch.
* If you don't require a custom branch, leave the configuration setting blank.

# Using

## Default behavior

Typing `AbatabLieutenant.exe` will display the help information

## Deploying an Abatab branch

To deploy a specific branch of Abatab, open a terminal and type `AbatabLieutenant.exe %BranchName%`.

For example: `> AbatabLieutenant.exe testing`

Abatab Lieutenant will then:

1. Download the latest **testing** branch of Abatab
2. Deploy the **testing** branch to **C:\Abatab\UAT**

## Default deployable Abatab branches

The following Abatab branches are available for deployment via Abatab Lieutenant:

* development
* main
* testing

For example, to deploy the **main** branch, you would open a terminal and type `AbatabLieutenant.exe main`

## Deploying a custom branch of Abatab

You can use the CustomBranch configuration setting to allow a custom branch to be deployed, and follows these rules:

* The CustomBranch name needs to be the `%filename%` part of `%filename%.zip`.
* There can only be one custom branch.
* If you don't require a custom branch, leave the configuration setting blank.

For example, to deploy the **MyBranch** branch of Abatab, you would:

1. Modify the CustomBranch configuration setting to be `%MyBranch%`
2. Open a terminal and type `AbatabLieutenant.exe %MyBranch%`.

## Getting help

To display the Abatab Lieutenant help information, type `AbatabLieutenant.exe`

# Logs

Abatab Lieutenant logs can be found here in **%LtntRoot%\lieutenant\logs\\**.

***

<br>

<div align="center">

  ![LastCommit][LastCommit]&nbsp;&nbsp;&nbsp;![CodeSize][CodeSize]&nbsp;&nbsp;&nbsp;![LinesOfCode][LinesOfCode]&nbsp;&nbsp;&nbsp;![RepoFileCount][RepoFileCount]&nbsp;&nbsp;&nbsp;![RepoSize][RepoSize]
  <br>
  <br>

  Abatab Lieutenant is developed by [A Pretty Cool Program][APrettyCoolProgramUrl].

</div>

<!-- Top row -->
[GitHubFollowers]: https://img.shields.io/github/followers/spectrum-health-systems?style=social
[GitHubForks]: https://img.shields.io/github/forks/spectrum-health-systems/AbatabLieutenant?style=social
[GitHubStars]: https://img.shields.io/github/stars/spectrum-health-systems/AbatabLieutenant?style=social
[GitHubWatchers]: https://img.shields.io/github/watchers/spectrum-health-systems/AbatabLieutenant?style=social
[DotNet]: https://img.shields.io/badge/.NET-6.0-blueviolet

[AbatabUrl]: https://github.com/spectrum-health-systems/Abatab
[MainBranchUrl]: README.md
[Logo]: ./resources/images/logos/AbatabLieutenantLogo.png
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
