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
      - etc.

Accessed via. command line arguments:

Default: `QuickLauncher.exe 0`

`QuickLauncher.exe 1`

etc.

### Use `Tab` / `Shift + Tab` to navigate list

```
> App 1
  App 2
  App 3
```
