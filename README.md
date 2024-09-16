# QuickLauncher
 
Keyboard-based Windows start menu alternative

App is launched when it is the only result that matches you query

Put shortcut files in `%appdata%\QuickLauncher\Apps\0` to add to apps list

| Key       | Function                      |
| :-------- | :---------------------------- |
| Tab       | Navigate apps list (forward)  |
| Shift+Tab | Navigate apps list (backward) |
| Enter     | Open selected item            |
| Esc       | Exit                          |
| F12       | Open apps directory           |

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

### Folders

You can add QuickLauncher as an app to redirect to a different apps list
