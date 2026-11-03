_其他语言版本: [English](README.md), [中文](README.zh-CN.md)_

# <img src="EverythingToolbar/Images/AppIcon.ico" width="24"> EverythingToolbar

<a href="https://github.com/Crucialmer/EverythingToolbar/releases/latest"><img src="https://img.shields.io/github/v/release/Crucialmer/EverythingToolbar?color=blue" height="25" /></a>
<a href="https://github.com/Crucialmer/EverythingToolbar/releases/latest"><img src="https://img.shields.io/github/downloads/Crucialmer/EverythingToolbar/total?color=critical" height="25" /></a>
<a href="https://dotnet.microsoft.com/en-us/download/dotnet/10.0"><img src="https://img.shields.io/badge/.NET-10.0%20LTS-purple.svg" height="25" /></a>

为 Windows 任务栏提供即时文件搜索集成，由 [Everything](https://www.voidtools.com/) 驱动。

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
  - 启动或在「高级」设置中一键检测新版发布，随时获取最新特性。
- **100% 纯绿色免安装架构**：
  - 抛弃侵入式 COM Deskband，采用无侵入 Launcher 模式。
  - **零系统写入**：配置（`settings.ini`）、规则（`rules.xml`）与日志（`EverythingToolbar.log`）全部严格保存在程序根目录下的 `./Config` 文件夹中，完全不向 `%APPDATA%`、`%TEMP%` 或 Windows 注册表写入任何多余文件。
- **框架依赖轻量化发布**：由于系统已预装 .NET 10，软件未打包冗余运行时，解压即用，体积极致轻盈（仅约 14MB）。
- **发布包**：`release/EverythingToolbar.zip`。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/demo.gif" alt="EverythingToolbar演示" width="80%">

## 🌟 功能特点

### 任务栏集成
EverythingToolbar 位于您的任务栏上，既可以作为直接在 Windows 11 上键入的搜索框，也可以作为点击打开搜索窗口的紧凑图标。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/taskbar_modes.png" alt="任务栏搜索框与搜索图标" width="80%">

您可以在设置过程中选择，也可以随时在 **设置** → **任务栏集成** 中切换。此外，在 Windows 10 上 EverythingToolbar 还可以作为原生桌面栏集成。

### 明暗主题自适应
EverythingToolbar 无缝融入 Windows 10 和 11，自动跟随系统主题切换明亮/暗黑模式。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/fast.png" alt="明亮和暗黑主题" width="80%">

### 自定义搜索过滤器
EverythingToolbar 内置常用搜索过滤器。对于高级用户，它可以与 Everything 的自定义过滤器同步，让您完全掌控搜索体验。在 EverythingToolbar 的 **过滤器** 设置中勾选 **使用 Everything 过滤器** 即可启用。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/flexible.png" alt="自定义搜索过滤器" width="80%">

### 快速切换搜索选项
轻松切换搜索标志（区分大小写、全字匹配、匹配路径和正则表达式）以精确查找文件。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/on_point.png" alt="快速切换" width="80%">

### 基于正则表达式的文件操作
在 **设置** → **自定义操作** 中创建自定义的 **打开方式**。启用 **根据条件自动应用规则** 可以基于文件类型和正则表达式自动执行指定命令。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/custom_actions.png" alt="自定义操作选项" width="80%">

### 兼容性
EverythingToolbar 在 Windows 10 和 Windows 11 上均可顺畅运行。在 Windows 11 上，任务栏搜索框开箱即用地嵌入任务栏；如需完整桌面栏支持，还可与 [ExplorerPatcher](https://github.com/valinet/ExplorerPatcher) 及 [StartAllBack](https://www.startallback.com/) 深度搭配。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/compatible.png" alt="Windows 10截图" width="80%">

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
3. 直接双击运行 `EverythingToolbar.Launcher.exe`。
4. 所有的配置、规则及运行日志均隔离在软件根目录 `./Config/` 下，绝不写入 Windows 注册表与 `%APPDATA%`。
