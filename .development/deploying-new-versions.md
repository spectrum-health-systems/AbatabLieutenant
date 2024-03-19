# Deploying new versions of AbatabLieutenant

1. Change the version numbers in `AbatabLieutenant.csproj`
   
Before:

```
<Version>4.2.0.0</Version>
<FileVersion>4.2.0.0</FileVersion>
```

After:

```
<Version>4.3.0.0</Version>
<FileVersion>4.3.0.0</FileVersion>
```

2. Change the version/build numbers in AbatabLieutenant.LtSession.CreateDefaultSettings()

Before:

```
LtVer                 = "4.1",
LtBld                 = "240318",
```

After:

```
LtVer                 = "4.3",
LtBld                 = "240319",
```
