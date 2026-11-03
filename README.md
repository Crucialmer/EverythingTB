_Read in other languages: [English](README.md), [中文](README.zh-CN.md)_

# <img src="EverythingToolbar/Images/AppIcon.ico" width="24"> EverythingToolbar

<a href="https://github.com/Crucialmer/EverythingToolbar/releases/latest"><img src="https://img.shields.io/github/v/release/Crucialmer/EverythingToolbar?color=blue" height="25" /></a>
<a href="https://github.com/Crucialmer/EverythingToolbar/releases/latest"><img src="https://img.shields.io/github/downloads/Crucialmer/EverythingToolbar/total?color=critical" height="25" /></a>
<a href="https://dotnet.microsoft.com/en-us/download/dotnet/10.0"><img src="https://img.shields.io/badge/.NET-10.0%20LTS-purple.svg" height="25" /></a>

Instant file search integration for Windows powered by [Everything](https://www.voidtools.com/).

## 🚀 EverythingToolbar v1.3.0 特性亮点

- **全套基于 macOS 26 设计美学（全新进化）**：
  - **结果匹配字符色彩提醒**：告别单调纯粗体，将搜索匹配字优化为 Apple Vibrant Blue 动态色彩提醒（暗色模式 `#2997FF` / 亮色模式 `#0071E3`）与 SemiBold 半粗体字重，字符定位更醒目晶莹。
  - **选中结果高亮提醒**：采用 macOS 26 Spotlight 列表设计，选中行呈现柔和 Apple Blue 胶囊背板、发光微边框（`BorderThickness="1"`）以及左侧圆角侧标指示器（Vertical Accent Indicator Pill）。
  - **开箱默认「普通（详细）」双行视图**：全新安装或默认状态下直显文件名与所在文件夹路径，无需手动切换即可获知目标文件所在位置。
- **搜索框与结果全套排版定制**：
  - **搜索框字体大小与样式**：支持 9 pt 至 16 pt（默认 11 pt）及 常规 / 中等 / 半粗 / 加粗 样式设置。
  - **搜索结果字体大小与样式**：支持 9 pt 至 16 pt（默认 11 pt）及 常规 / 中等 / 半粗 / 加粗 自由定制，在「设置」→「界面」中实时动态预览。
- **全屏支持 8K 超高分辨率与无损 DPI 缩放**：
  - **原生 Per-Monitor V2 深度适配**：支持从 100% 至 500%+ 任意 DPI 缩放比例，跨显示器拖拽无缝自适应。
  - **8K 级别超清图标解析**：集成 Windows Shell Jumbo（256×256）超大图标图库与多阶动态回退，告别模糊发虚。
  - **双重多采样高质过滤**：全局启用 `RenderOptions.BitmapScalingMode="HighQuality"` 与 `SnapsToDevicePixels="True"`，微像素级边缘抗锯齿。
- **自定义项目自动更新与检测**：
  - 软件更新源深度对接当前仓库：`https://github.com/Crucialmer/EverythingToolbar`。
  - 启动或在「高级」设置中一键检测新版发布，保持最新功能。
- **100% 纯绿色免安装架构**：
  - 抛弃侵入式 COM Deskband，采用无侵入 Launcher 模式。
  - **零系统写入**：配置（`settings.ini`）、规则（`rules.xml`）与日志（`EverythingToolbar.log`）全部严格保存在程序根目录下的 `./Config` 文件夹中，完全不向 `%APPDATA%`、`%TEMP%` 或 Windows 注册表写入任何多余文件。
- **框架依赖轻量化发布**：由于系统已预装 .NET 10，软件未打包冗余运行时，解压即用，体积极致轻盈（仅约 14MB）。
- **统一通用发布包**：`release/EverythingToolbar.zip`。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/demo.gif" alt="EverythingToolbar in action" width="80%">

## 🌟 Features

### Taskbar Integration
EverythingToolbar sits right on your taskbar, either as a real search box you can type into directly on Windows 11, or as a compact icon that opens the search window when clicked.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/taskbar_modes.png" alt="Taskbar search box and search icon" width="80%">

Choose either during setup or switch anytime under **Settings** → **Taskbar integration**. Additionally, on Windows 10 EverythingToolbar can be integrated as a native deskband.

### Light & Dark Themes
EverythingToolbar seamlessly blends into Windows 10 and 11, automatically adjusting to your system theme with macOS 26 vibrant accent highlights.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/fast.png" alt="Light and dark themes" width="80%">

### Custom Search Filters
EverythingToolbar includes common search filters out of the box. For advanced users, it can synchronize with Everything's custom filters, giving you complete control over your search experience. Enable this feature by checking **Use Everything filters** in the EverythingToolbar's **Filters** settings.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/flexible.png" alt="Custom search filters" width="80%">

### Quick Search Options
Easily toggle search flags (match case, whole word, match path, and regex) to find your files with precision.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/on_point.png" alt="Quick toggles" width="80%">

### RegEx-Powered File Actions
Create custom **Open with** actions by navigating to **Settings** → **Custom actions**. Enable **Automatically apply rules based on condition** to execute commands automatically based on file type and regular expressions. Leave the regex field empty to display the action only in the context menu.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/custom_actions.png" alt="Custom action options" width="80%">

### Compatibility
EverythingToolbar works seamlessly on Windows 10 and Windows 11. On Windows 11 the taskbar search box embeds into the taskbar out of the box, and for full deskband support it integrates with tools like [ExplorerPatcher](https://github.com/valinet/ExplorerPatcher) and [StartAllBack](https://www.startallback.com/).

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/compatible.png" alt="Windows 10 screenshot" width="80%">

### Additional Features

- Access EverythingToolbar instantly via customizable global shortcut (<kbd>Win</kbd> + <kbd>Alt</kbd> + <kbd>S</kbd>)
- Default double-line path view (`NormalDetailed`) on clean startup
- Vibrant macOS 26 accent highlights for matched query characters and selected rows
- Fully customizable font size (9 pt to 16 pt) and font weight for both search box and results
- 8K resolution and ultra-high DPI scaling support (100% to 500%+)
- Drag and drop files directly from search results
- Preview files with [QuickLook](https://github.com/QL-Win/QuickLook) or [Seer](http://1218.io/) integration
- Support for custom Everything [instance names](https://www.voidtools.com/support/everything/multiple_instances/#named_instances)

### 快捷键一览

| 快捷键 | 功能 |
|---|---|
| <kbd>↑</kbd> / <kbd>↓</kbd> | 浏览搜索结果 |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> / <kbd>↓</kbd> | 浏览搜索历史（若已启用） |
| <kbd>Enter</kbd> / <kbd>点击</kbd> | 打开文件或文件夹 |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> / <kbd>点击</kbd> | 打开所在文件夹 |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> / <kbd>点击</kbd> | 在 Everything 中打开 |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>C</kbd> | 复制完整路径至剪贴板 |
| <kbd>Alt</kbd> + <kbd>Enter</kbd> / <kbd>点击</kbd> | 查看属性 |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>Enter</kbd> / <kbd>点击</kbd> | 以管理员身份运行 |
| <kbd>Shift</kbd> + <kbd>右键</kbd> | 打开系统右键菜单 |
| (<kbd>Shift</kbd> +) <kbd>Tab</kbd> | 循环切换过滤器 |
| <kbd>Ctrl</kbd> + <kbd>0-9</kbd> | 依编号选择过滤器 |
| <kbd>Space</kbd> | 在 QuickLook 中预览文件 |
| <kbd>Win</kbd> + <kbd>Alt</kbd> + <kbd>S</kbd> | 激活搜索框（可自定义） |

## 📦 安装与绿色运行

### 环境准备
- Windows 10 或 Windows 11
- [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [Everything](https://www.voidtools.com) ≥ 1.4.1 (x64) 并在后台运行

### 快速启动（绿色便携版）
1. 从 [GitHub Releases](https://github.com/Crucialmer/EverythingToolbar/releases/latest) 下载 `EverythingToolbar.zip`。
2. 解压到任意您喜欢的文件夹。
3. 双击运行 `EverythingToolbar.Launcher.exe`（或 `启动EverythingToolbar.bat`）。
4. **运行说明**：
   - 软件启动后会在后台常驻守护，并在 Windows 任务栏右下角托盘区（或 `^` 隐藏托盘图标）显示小放大镜图标；
   - 随时按下全局快捷键 **`Win` + `Alt` + `S`** 即可呼出/隐藏搜索栏；
   - 若软件已在后台运行，再次点击运行可执行文件也会直接唤出搜索界面；
   - 右键右下角托盘图标可随时进入「首选项设置」或退出程序。
5. 所有的配置、规则及运行日志均隔离在软件根目录 `./Config/` 下，绝不写入 Windows 注册表与 `%APPDATA%`。
