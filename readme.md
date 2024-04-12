Serve single file TiddlyWiki from local file storage with autosave enabled by simulating GitHub saver.

# Run the app
`dotnet run` will make the app available at http://localhost:5115.

Publish the app to a single file: `dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained true`. Output other than `tiddly-filesaver.exe` is not required. From a PowerShell terminal, run `tiddly-filesaver.exe` to access the application at http://localhost:5000/.

# Configuration
Setup GitHub saver in the TiddlyWiki file.

| Setting | Value |
| ------- | ----- |
| Username | Literally anything |
| Target repository | {username}/{anything - keep it simple!} |
| Target branch for saving | Doesn't matter |
| Path to target file | Leave empty |
| Server API URL | Should be the same as the URL in the browser after running the application |

In appsettings.json:
``` JSON
{
  "FilePath": "fully qualified path to TiddlyWiki .html file",
  "RequestPath": "/repos/{Target repository defined in TiddlyWiki GitHub saver}/contents"
}
```
