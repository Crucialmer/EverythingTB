_Read in other languages: [English](README.md), [中文](README.zh-CN.md)_

# <img src="EverythingToolbar/Images/AppIcon.ico" width="24"> EverythingToolbar

<a href="https://github.com/Crucialmer/EverythingToolbar/releases/latest"><img src="https://img.shields.io/github/v/release/Crucialmer/EverythingToolbar?color=blue" height="25" /></a>
<a href="https://github.com/Crucialmer/EverythingToolbar/releases/latest"><img src="https://img.shields.io/github/downloads/Crucialmer/EverythingToolbar/total?color=critical" height="25" /></a>
<a href="https://dotnet.microsoft.com/en-us/download/dotnet/10.0"><img src="https://img.shields.io/badge/.NET-10.0%20LTS-purple.svg" height="25" /></a>

Instant file search integration for Windows powered by [Everything](https://www.voidtools.com/).

## 🚀 EverythingToolbar v1.4.0 特性亮点

- **内置原生直连自动更新（全新升级）**：
  - **绝不跳转浏览器**：检测到新版后点击「立即更新」，软件在后台直连 GitHub 发布服务器流式下载，实时展示下载百分比。
  - **无感静默替换**：下载完毕自动解压、安全终止旧进程并无缝替换程序文件，重启后立即生效。
  - **配置完全保留**：绿色便携目录下的 `./Config` 文件夹（包含您的个性化设置 `settings.ini` 与自定义规则 `rules.xml`）受到严格保护，更新绝不丢失任何数据。
- **macOS 26 任务栏日期与星期胶囊组件（全新组件）**：
  - **弥补 Win11 任务栏信息缺陷**：在任务栏主搜索框右侧优雅嵌入极简日期与星期胶囊（如 `11月3日 周二`），一眼掌控日程时间。
  - **macOS 26 磨砂药丸美学**：采用透明磨砂亚克力微光底色、1px 发光轮廓与 Apple 标志性蓝色日历图标，悬停呈现高光过渡。
  - **一键快捷呼出日历**：单击日期胶囊即可直接呼出 Windows 11 原生通知中心与系统日历飞窗。
  - **灵活可控**：在「设置」→「界面」中提供专属开关，可随心开启或隐藏。
- **全套基于 macOS 26 设计美学**：
  - **搜索匹配字色彩高亮提醒**：搜索结果中匹配的字符呈现 Apple 标志性 Vibrant Blue 动态色彩提醒（暗色 `#2997FF` / 亮色 `#0071E3`）与 SemiBold 样式。
  - **选中结果高亮提醒**：macOS 26 Spotlight 列表设计，选中行呈现柔和微光胶囊背板与左侧圆角侧标指示器（Vertical Accent Indicator Pill）。
  - **默认「普通（详细）」双行视图**：全新安装或默认状态下直显文件名与所在文件夹路径。
- **搜索框与结果全套排版定制**：
  - 搜索框与搜索结果均支持 9 pt 至 16 pt（默认 11 pt）及 常规 / 中等 / 半粗 / 加粗 样式设置与实时预览。
- **全屏支持 8K 超高分辨率与无损 DPI 缩放**：
  - 原生 Per-Monitor V2 深度适配，集成 Windows Shell Jumbo 256×256 超清图标与双重高质抗锯齿过滤。
- **100% 纯绿色免安装架构**：
  - 零系统写入，程序与配置完全自包含在软件目录。
  - 仅发布单一通用绿色包：`EverythingToolbar.zip`。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/demo.gif" alt="EverythingToolbar in action" width="80%">

## 🌟 Features

### Taskbar Integration & macOS 26 Date Widget
EverythingToolbar sits right on your taskbar with an optional macOS 26 style Date & Day of Week pill widget next to the search box, bringing convenient calendar access and date visibility to Windows 11.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/taskbar_modes.png" alt="Taskbar search box and search icon" width="80%">

### In-App Direct Auto-Update
Check, download, and install updates directly within the application without being redirected to GitHub in an external browser. All user data in `./Config/` is safely preserved across updates.

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
Create custom **Open with** actions by navigating to **Settings** → **Custom actions**. Enable **Automatically apply rules based on condition** to execute commands automatically based on file type and regular expressions.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/custom_actions.png" alt="Custom action options" width="80%">

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
   - 软件启动后会在后台常驻守护，并在 Windows 任务栏右下角托盘区显示小放大镜图标；
   - 任务栏主搜索框右侧会显示精致的日期与星期胶囊（点击可直接打开系统日历）；
   - 随时按下全局快捷键 **`Win` + `Alt` + `S`** 即可呼出/隐藏搜索栏；
   - 软件支持在应用内直接检查、静默下载并自动安装最新版本，绝不跳转浏览器；
   - 所有的配置、规则及运行日志均隔离在软件根目录 `./Config/` 下，绝不写入 Windows 注册表与 `%APPDATA%`。
