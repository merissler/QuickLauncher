# QuickLauncher
 
Windows Start Menu Alternative

App is launched when it is the only result that matches you query

Put shortcut files in `%appdata%\QuickLauncher\Apps\`

| Key   | Function                |
| ----- | ----------------------- |
| Tab   | Navigate apps list      |
| Enter | Open first item in list |
| Esc   | Exit                    |

### Can have multiple apps directories
- %AppData%
  - QuickLauncher
    - Apps
      - 0
      - 1
      - 2
      - test
      - Your_Folder
      - etc.

Accessed via. command line arguments:

Default: `QuickLauncher.exe 0`

`QuickLauncher.exe 1`

`QuickLauncher.exe Your_Folder`

etc.

### Use `Tab` / `Shift + Tab` to navigate list

```
> App 1
  App 2
  App 3
```

### Nesting

If you want, you can put a shortcut to Quick Launcher that targets a different subdirectory in the apps folder
