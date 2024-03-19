# Deploying new versions of AbatabLieutenant

## Update `AbatabLieutenant.csproj`
   
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

## Update `AbatabLieutenant.LtSession.CreateDefaultSettings()`

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
