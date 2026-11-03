_其他语言版本: [English](README.md), [中文](README.zh-CN.md)_

# <img src="EverythingToolbar/Images/AppIcon.ico" width="24"> EverythingTB

<a href="https://github.com/Crucialmer/EverythingTB/releases/latest"><img src="https://img.shields.io/github/v/release/Crucialmer/EverythingTB?color=blue" height="25" /></a>
<a href="https://github.com/Crucialmer/EverythingTB/releases/latest"><img src="https://img.shields.io/github/downloads/Crucialmer/EverythingTB/total?color=critical" height="25" /></a>
<a href="https://dotnet.microsoft.com/en-us/download/dotnet/10.0"><img src="https://img.shields.io/badge/.NET-10.0%20LTS-purple.svg" height="25" /></a>

为 Windows 任务栏提供即时文件搜索集成，由 [Everything](https://www.voidtools.com/) 驱动。

## 🚀 EverythingTB v1.7.5 特性亮点

- **智能动态字体样式（自适应苹方等 100~900 完整 9 档字重）**：
  - 彻底打破先前静态 4 档字重限制，重构字重探测引擎，能够智能匹配当前所选字体支持的全部物理字重规格。
  - 针对苹果 **苹方（PingFang SC / TC / HK）**、思源黑体及可变字族全面适配完整的 9 档字重粗细（100 极细、200 纤细、300 细体、400 常规、500 中黑、600 中粗、700 粗体、800 特粗、900 黑体）。
  - 针对特定字体（如 Segoe UI 包含 350 Semilight 等特定档位）智能呈现原生字重命名，切换字体即刻联动刷新样式选项。

- **启动零弹窗，极速静默驻留（Silent Direct Launch）**：
  - 彻底优化启动流程，打开或开机自启时不再弹出窗口打扰用户，直接静默运行并驻留任务栏托盘。
  - 采用后台无感预热机制（PreWarm），按下快捷键（`Win+Alt+S`）或点击托盘图标即可毫秒级即刻唤出。

- **极致纯净架构（零历史包袱，100% 专注 EverythingTB）**：
  - 彻底移除所有过渡兼容文件与遗留脚本，压缩包内仅保留唯一原生主程序 **`EverythingTB.exe`**。
  - 全面清理代码库中的历史残留：更新服务直接拉起 EverythingTB、托盘悬浮提示升级为 EverythingTB、开机自启全面适配 EverythingTB 并自动清理旧项。
  - 历史搜索记录完全绿色化（`Config/history.xml`），实现真正的全便携免安装。

- **关于页面与链接全维对齐**：
  - 「关于」页面横幅标题与所有官方文档、代码仓库链接全面更新至最新的 EverythingTB 项目主页。

- **隐藏空搜索默认开启（Spotlight 极简启动体验）**：
  - 「设置」→「搜索」→「行为」中的「隐藏空搜索」默认调整为**开启**状态。
  - 唤起搜索窗口时不再默认铺满未筛选的冗余文件，呈现纯净高级的 Spotlight 输入飞窗；键入关键词即刻毫秒响应检索。

- **品牌全维升级为 EverythingTB**：
  - 项目名称、发布包名、软件窗口及应用内标识全面升级为 **EverythingTB**，更加简洁利落。
  - 单一纯绿色发行包更名为 **`EverythingTB.zip`**，解压后直接双击带有图标的 `EverythingTB.exe` 即可畅爽搜索。

- **深度融合 macOS 26 设计美学（macOS 26 Design Aesthetic）**：
  - **浮动毛玻璃晶透卡片（Floating Translucent Glass Card）**：搜索主弹窗采用 14px 优雅大圆角与 1px 微光半透明外轮廓线（Subtle 1px Luminous Translucent Border），光影自然通透，呈现极致高级的 macOS 悬浮卡片质感。
  - **极简药丸预览侧栏（Pill-style Preview Pane）**：右侧预览面板加入精致半透明边框与圆角包边，与搜索卡片浑然一体。
  - **macOS 26 & Fluent 排版层级调优**：默认全局字体采用动态光学字族 `Segoe UI Variable Text`，中文优雅回退至微软雅黑，数字、字母、符号具有极高清晰度与现代感。
  - **Spotlight 药丸选区与色彩高亮**：结果列表项采用 8px 圆角药丸背板、Apple 标志性 Vibrant Blue 搜索词高亮（`#2997FF` / `#0071E3`）与垂直指示标。
  - **任务栏日期与星期胶囊组件微调优**：集成防抖与无冗余渲染机制，点击可一键直达系统日历。

- **代码全维优化与零损耗运行**：
  - **CPU 与重绘极致精简**：优化后台日期刷新机制与字体转换器，彻底杜绝无效的 UI 布局重排。
  - **原生 Per-Monitor V2 8K 超高清支持**：100%~500%+ 任意 DPI 缩放零失真，Shell Jumbo（256×256）超大图标图库解析。
  - **应用内直连自动更新**：更新源直连当前仓库 `Crucialmer/EverythingTB`，一键无感下载静默替换升级，配置与自定义规则严格保存在 `./Config` 绝不丢失。
  - **100% 纯绿色免安装**：零注册表残留，无需安装任何后台驱动，体积极致轻盈。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/demo.gif" alt="EverythingTB演示" width="80%">

## 🌟 功能特点

### 任务栏集成
EverythingTB 位于您的任务栏上，既可以作为直接在 Windows 11 上键入的搜索框，也可以作为点击打开搜索窗口的紧凑图标。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/taskbar_modes.png" alt="任务栏搜索框与搜索图标" width="80%">

您可以在设置过程中选择，也可以随时在 **设置** → **任务栏集成** 中切换。此外，在 Windows 10 上 EverythingTB 还可以作为原生桌面栏集成。

### 明暗主题自适应
EverythingTB 无缝融入 Windows 10 和 11，自动跟随系统主题切换明亮/暗黑模式。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/fast.png" alt="明亮和暗黑主题" width="80%">

### 自定义搜索过滤器
EverythingTB 内置常用搜索过滤器。对于高级用户，它可以与 Everything 的自定义过滤器同步，让您完全掌控搜索体验。在 EverythingTB 的 **过滤器** 设置中勾选 **使用 Everything 过滤器** 即可启用。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/flexible.png" alt="自定义搜索过滤器" width="80%">

### 快速切换搜索选项
轻松切换搜索标志（区分大小写、全字匹配、匹配路径和正则表达式）以精确查找文件。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/on_point.png" alt="快速切换" width="80%">

### 基于正则表达式的文件操作
在 **设置** → **自定义操作** 中创建自定义的 **打开方式**。启用 **根据条件自动应用规则** 可以基于文件类型和正则表达式自动执行指定命令。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/custom_actions.png" alt="自定义操作选项" width="80%">

### 兼容性与高分辨率
EverythingTB 在 Windows 10 和 Windows 11 上均可顺畅运行，原生支持 8K/4K 超高分显示屏与各级缩放比例。在 Windows 11 上，任务栏搜索框开箱即用地嵌入任务栏；如需完整桌面栏支持，还可与 [ExplorerPatcher](https://github.com/valinet/ExplorerPatcher) 及 [StartAllBack](https://www.startallback.com/) 深度搭配。

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
1. 从 [GitHub Releases](https://github.com/Crucialmer/EverythingTB/releases/latest) 下载 `EverythingTB.zip`。
2. 解压到任意您喜欢的文件夹。
3. 直接双击运行带有图标的 `EverythingTB.exe` 即可。
4. 所有的配置、规则及运行日志均隔离在软件根目录 `./Config/` 下，绝不写入 Windows 注册表与 `%APPDATA%`。
