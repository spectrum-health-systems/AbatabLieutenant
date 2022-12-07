
<div align="center">

![Followers][GitHubFollowers] ![Forks][GitHubForks] ![Stars][GitHubStars] ![Watchers][GitHubWatchers]

[![Logo][Logo]][MainBranchUrl]

### Command line management utility for Abatab

![Status][Status]&nbsp;&nbsp;&nbsp;[![License][License]][LicenseUrl]&nbsp;&nbsp;&nbsp;![.NET][DotNet]&nbsp;&nbsp;&nbsp;![CurrentRelease][CurrentRelease]

</div>

<!-- The HTML indentations have to stay this way to work. -->
<table>
<tr>
<td img src="RepositoryData/Asset/Image/Document/README/spacer.png" alt="blank-spacer" width="1000" height="1">

  ### CONTENTS
  [ABOUT](#about)<br>
  [GETTING STARTED](#getting-started)<br>
  [INSTALLING](#installing)<br>
  [USING](#using)<br>
  [UPDATING](#updating)<br>
  [UNINSTALLING](#uninstalling)<br>
  [DEVELOPMENT](#development)<br>
  [ADDITIONAL INFORMATION](#additional-information)<br>

</td>
</tr>
</table>

***

# About

Abatab Lieutenant is a simple utility that deploys branches of Abatab to the server where where Abatab is hosted.

# Using

To use Abatab Lieutenant:

1. Download the latest [release](https://github.com/spectrum-health-systems/AbatabLieutenant/releases)

2. Uncompress the .zip file to the server where Abatab is hosted

3. Verify that the configuration settings in `AbatabLieutenant.exe.config` are correct

4. Run `AbatabLieutenant.exe`

## Default behavior

The default Abatab Lieutenant behavior is to deploy the `testbuild` branch of Abatab to to `C:\Abatab\UAT`.

## Runtime behavior

You can display the help screen, or specify another branch to deploy, at runtime by using the following syntax:

``` bash
AbatabLieutenant.exe <command>
```

For example:

``` bash
AbatabLieutenant.exe help
```

The following are valid Abatab Lieutenant commands:

* `help`  
Abatab Lieutenant help (this screen)

* `development`  
Deploy the Abatab development branch

* `experimental`  
Deploy the Abatab experimental branch

* `main`  
Deploy the Abatab main branch

* `testbuild`  
Deploy the Abatab tesbuild branch (default)

# Configuring

You can also change the default behavior of Abatab Lieutenant by modifying the values in `AbatabLieutenant.exe.config`.

> DebugMode = disabled

Specifies if debugging information will be displayed on the screen when you run Abatab Lieutenant.

DebugMode can either be `enabled` or `disabled`.

> LtntVersion = 2.0

The version of Abatab Lieutenant.

> LtntRoot = C:\Abatab\UAT

The root directory where Abatab will be deployed.

> RepoUrl = https://github.com/spectrum-health-systems/Abatab/archive/refs/heads/

The base URL for the Abatab branches.

> DefaultBranch = testbuild  

The Abatab branch to deploy when typing `AbatabLieutenant.exe`.  This can be one of the following branches:

* `development`

* `main`

* `testbuild`

* `experimental`

# Logging

Abatab Lieutenant logs can be found here:  
`C:\Abatab\UAT\logs\lieutenant\`


![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/spectrum-health-systems/AbatabLieutenant)
![Lines of code](https://img.shields.io/tokei/lines/github/spectrum-health-systems/AbatabLieutenant)
![GitHub repo file count](https://img.shields.io/github/directory-file-count/spectrum-health-systems/AbatabLieutenant)
![GitHub repo size](https://img.shields.io/github/repo-size/spectrum-health-systems/AbatabLieutenant)
![GitHub all releases](https://img.shields.io/github/downloads/spectrum-health-systems/AbatabLieutenant/total)
![GitHub issues](https://img.shields.io/github/issues/spectrum-health-systems/AbatabLieutenant)
![GitHub pull requests](https://img.shields.io/github/issues-pr/spectrum-health-systems/AbatabLieutenant)
![GitHub](https://img.shields.io/github/license/spectrum-health-systems/AbatabLieutenant)

![GitHub last commit](https://img.shields.io/github/last-commit/spectrum-health-systems/AbatabLieutenant)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/spectrum-health-systems/AbatabLieutenant/development)














<!-- REFERENCE LINKS -->

[GitHubFollowers]: https://img.shields.io/github/followers/spectrum-health-systems?style=social
[GitHubForks]: https://img.shields.io/github/forks/spectrum-health-systems/AbatabLieutenant?style=social
[GitHubStars]: https://img.shields.io/github/stars/spectrum-health-systems/AbatabLieutenant?style=social
[GitHubWatchers]: https://img.shields.io/github/watchers/spectrum-health-systems/AbatabLieutenant?style=social

[DotNet]: https://img.shields.io/badge/.NET-6.0-blueviolet













[AbatabRepoUrl]: https://github.com/spectrum-health-systems/Abatab
[MainBranchUrl]: README.md
[Logo]: /.github/res/img/logo/RepositoryLogo.png
[Status]: https://img.shields.io/badge/status-active-brightgreen?style=flat
[License]: https://img.shields.io/badge/license-apache%202.0-brightgreen?style=flat
[LicenseUrl]: https://www.apache.org/licenses/LICENSE-2.0
[CurrentRelease]: https://img.shields.io/github/v/release/spectrum-health-systems/AbatabLieutenant?style=flat
[CurrentReleaseUrl]: https://github.com/spectrum-health-systems/AbatabLieutenant/releases
[Changelog]: /doc/CHANGELOG.md
[Roadmap]: /doc/ROADMAP.md
[ManHome]: /doc/man/ManHome.md
[SrcDocHome]: /doc/srcdoc/SrcDocHome.md
