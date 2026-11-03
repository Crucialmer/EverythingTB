_Read in other languages: [English](README.md), [中文](README.zh-CN.md)_

# <img src="EverythingToolbar/Images/AppIcon.ico" width="24"> EverythingToolbar

<a href="https://github.com/Crucialmer/EverythingToolbar/releases/latest"><img src="https://img.shields.io/github/v/release/Crucialmer/EverythingToolbar?color=blue" height="25" /></a>
<a href="https://github.com/Crucialmer/EverythingToolbar/releases/latest"><img src="https://img.shields.io/github/downloads/Crucialmer/EverythingToolbar/total?color=critical" height="25" /></a>
<a href="https://dotnet.microsoft.com/en-us/download/dotnet/10.0"><img src="https://img.shields.io/badge/.NET-10.0%20LTS-purple.svg" height="25" /></a>

Instant file search integration for Windows powered by [Everything](https://www.voidtools.com/).

## 🚀 EverythingToolbar v1.1.0 特性亮点

- **.NET 10 LTS 升级**：基于全新 `.NET 10.0` 运行时构建，带来极致瞬时响应与低内存开销。
- **macOS 26 磨砂玻璃设计美学**：
  - 深度磨砂亚克力玻璃（Frosted Acrylic Glass）与 Obsidian/Milk White 双色调。
  - 胶囊搜索条（Capsule Pill）与圆角搜索框，精致聚焦微光。
  - 8px 优雅圆角列表项（Spotlight Row Selection）。
  - 适配现代系统字族（Segoe UI Variable / SF Pro / 微软雅黑）。
- **可自定义搜索结果字体大小（新增）**：
  - 默认采用精致黄金阅读尺寸 **11 pt**。
  - 在「设置」→「界面」中支持在 9 pt 至 16 pt 之间自由调节，实时预览并立即生效。
- **自定义项目自动更新与检测（新增）**：
  - 软件更新源深度对接当前仓库：`https://github.com/Crucialmer/EverythingToolbar`。
  - 启动或在「高级」设置中一键检测新版发布，保持最新功能。
- **100% 纯绿色免安装架构**：
  - 抛弃侵入式 COM Deskband，采用无侵入 Launcher 模式。
  - **零系统写入**：配置（`settings.ini`）、规则（`rules.xml`）与日志（`EverythingToolbar.log`）全部严格保存在程序根目录下的 `./Config` 文件夹中，完全不向 `%APPDATA%`、`%TEMP%` 或 Windows 注册表写入任何多余文件。
- **框架依赖轻量化发布**：由于系统已预装 .NET 10，软件未打包冗余运行时，解压即用，体积极致轻盈（仅约 14MB）。
- **发布包**：`release/EverythingToolbar.zip`。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/demo.gif" alt="EverythingToolbar in action" width="80%">

## 🌟 Features

### Taskbar Integration
EverythingToolbar sits right on your taskbar, either as a real search box you can type into directly on Windows 11, or as a compact icon that opens the search window when clicked.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/taskbar_modes.png" alt="Taskbar search box and search icon" width="80%">

Choose either during setup or switch anytime under **Settings** → **Taskbar integration**. Additionally, on Windows 10 EverythingToolbar can be integrated as a native deskband.

### Light & Dark Themes
EverythingToolbar seamlessly blends into Windows 10 and 11, automatically adjusting to your system theme.

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

- Access EverythingToolbar instantly via customizable global shortcut
- Drag and drop files directly from search results
- Preview files with [QuickLook](https://github.com/QL-Win/QuickLook) or [Seer](http://1218.io/) integration
- Support for custom Everything [instance names](https://www.voidtools.com/support/everything/multiple_instances/#named_instances)
- Customizable result font size (9 pt to 16 pt, default 11 pt)

### Keyboard Shortcuts

| Shortcut | Function |
|---|---|
| <kbd>↑</kbd> / <kbd>↓</kbd> | Navigate search results |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> / <kbd>↓</kbd> | Navigate search history (if enabled) |
| <kbd>Enter</kbd> / <kbd>Click</kbd> | Open file or folder |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> / <kbd>Click</kbd> | Open containing folder |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> / <kbd>Click</kbd> | Open in Everything |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>C</kbd> | Copy full path to clipboard |
| <kbd>Alt</kbd> + <kbd>Enter</kbd> / <kbd>Click</kbd> | Show file properties |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>Enter</kbd> / <kbd>Click</kbd> | Run as administrator |
| <kbd>Shift</kbd> + <kbd>Right Click</kbd> | Open system context menu |
| (<kbd>Shift</kbd> +) <kbd>Tab</kbd> | Cycle through filters |
| <kbd>Ctrl</kbd> + <kbd>0-9</kbd> | Select filter by number |
| <kbd>Space</kbd> | Preview file in QuickLook |
| <kbd>Win</kbd> + <kbd>Alt</kbd> + <kbd>S</kbd> | Focus search box (customizable) |

## 📦 Installation & Green Portable Run

### Prerequisites
- Windows 10 or Windows 11
- [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [Everything](https://www.voidtools.com) ≥ 1.4.1 (x64) installed and running

### Quick Start (Green Portable)
1. Download `EverythingToolbar.zip` from [GitHub Releases](https://github.com/Crucialmer/EverythingToolbar/releases/latest).
2. Extract to any folder.
3. Run `EverythingToolbar.Launcher.exe` directly.
4. All configurations and logs will be isolated inside `./Config/` without polluting Windows registry or `%APPDATA%`.
