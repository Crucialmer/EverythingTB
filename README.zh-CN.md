_语言 / Languages: [简体中文](README.md), [English](README.en.md)_

# <img src="EverythingToolbar/Images/AppIcon.ico" width="28" style="vertical-align: middle;"> EverythingTB

<p align="left">
  <a href="https://github.com/Crucialmer/EverythingTB/releases/latest"><img src="https://img.shields.io/github/v/release/Crucialmer/EverythingTB?color=0071E3&label=%E6%9C%80%E6%96%B0%E7%89%88%E6%9C%AC" height="22" /></a>
  <a href="https://github.com/Crucialmer/EverythingTB/releases/latest"><img src="https://img.shields.io/github/downloads/Crucialmer/EverythingTB/total?color=34C759&label=%E6%80%BB%E4%B8%8B%E8%BD%BD%E9%87%8F" height="22" /></a>
  <a href="https://dotnet.microsoft.com/en-us/download/dotnet/10.0"><img src="https://img.shields.io/badge/.NET-10.0%20LTS-AF52DE.svg" height="22" /></a>
  <a href="LICENSE.txt"><img src="https://img.shields.io/badge/%E5%BC%80%E6%BA%90%E5%8D%8F%E8%AE%AE-MIT-blue.svg" height="22" /></a>
</p>

> **EverythingTB** 是一款专为 Windows 打造的即时文件搜索工具，由 [Everything](https://www.voidtools.com/) 原生 SDK 强劲驱动。  
> 深度融合 **macOS 26 悬浮晶透毛玻璃美学** 与极简 **Spotlight** 交互哲学，带来丝滑优雅、开箱即用的现代化桌面全局检索体验。

---

## ✨ 核心特性

- ⚡ **毫秒级即时检索（Powered by Everything）**：基于 Everything 毫秒级索引库，键入即现，数百万文件瞬间极速响应。
- 🎨 **macOS 26 悬浮晶透美学**：14px 优雅悬浮卡片、1px 微光半透明轮廓线（Subtle Luminous Border），光影自然通透。
- 🔤 **智能全字重引擎（自适应苹方等 100~900 完整规格）**：彻底打破字体样式限制，全维支持苹果 **苹方（PingFang SC）**、思源黑体及可变字族的 9 档字重（100 极细 ~ 900 黑体），并智能匹配系统字体原生字重（如 Segoe UI 350 Semilight）。
- 🔇 **启动零弹窗，极速静默驻留**：打开或开机自启无任何弹窗打扰，直接静默入驻系统任务栏托盘；后台无感预热（PreWarm），按下快捷键（`Win + Alt + S`）即刻毫秒唤出。
- 🔍 **隐藏空搜索默认开启（Spotlight 极简启动）**：启动呼出时不再扑面而来大量未筛选的繁杂文件，呈现极简专注的搜索卡片，支持键入关键词即刻展开结果。
- 📦 **100% 纯绿色便携免安装**：单一绿色压缩包 `EverythingTB.zip`，配置文件、自定义操作规则与搜索历史全量隔离在 `./Config/` 目录，零注册表残留，免安装即开即用。
- 📅 **macOS 26 任务栏日期胶囊组件**：可选任务栏胶囊式日期与星期微件，补全 Windows 11 任务栏信息缺陷，支持一键直达系统日历。
- 🔄 **应用内直连自动更新**：告别浏览器手动跳转下载，软件内一键静默升级，自动保留用户所有配置。
- 🖥️ **原生 Per-Monitor V2 8K 超高清支持**：100%~500%+ 任意 DPI 缩放零失真，Shell Jumbo（256×256）超大图标图库解析。

---

## 📸 界面预览

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/demo.gif" alt="EverythingTB 演示" width="85%">

---

## 🌟 详细功能特点

### 1. 任务栏集成与无缝呼出
EverythingTB 既可以作为嵌入 Windows 任务栏的实时搜索框，也可以作为点击或快捷键唤醒的独立悬浮搜索图标。随时在「设置」→「任务栏集成」中自由切换。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/taskbar_modes.png" alt="任务栏搜索模式" width="80%">

### 2. 浅色与深色主题完美融合
无缝融入 Windows 10 与 Windows 11，支持跟随系统明暗主题实时自动切换，辅以 Apple Vibrant Blue 优雅高亮。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/fast.png" alt="明暗主题自适应" width="80%">

### 3. 同步 Everything 高级过滤器
内置多种常用文件过滤器（文档、图片、音乐、视频、程序等）。高级用户可在设置中开启「使用 Everything 过滤器」，与 Everything 本地的自定义分类与过滤规则实时双向同步。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/flexible.png" alt="自定义搜索过滤器" width="80%">

### 4. 快速搜索选项切换
在搜索面板中支持一键切换大小写匹配、全字匹配、路径匹配及正则表达式（Regex），精确匹配所需目标。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/on_point.png" alt="快速搜索选项" width="80%">

### 5. 正则表达式自定义动作
在「设置」→「自定义操作」中自定义「打开方式」。启用「根据条件自动应用规则」，可基于文件扩展名或路径正则自动匹配执行指定程序或参数。

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/custom_actions.png" alt="自定义操作" width="80%">

---

## ⌨️ 常用快捷键

| 快捷键 | 功能说明 |
|:---|:---|
| <kbd>Win</kbd> + <kbd>Alt</kbd> + <kbd>S</kbd> | **呼出 / 隐藏搜索框**（可在设置中自定义） |
| <kbd>↑</kbd> / <kbd>↓</kbd> | 浏览选择搜索结果 |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> / <kbd>↓</kbd> | 浏览历史搜索记录（若开启历史功能） |
| <kbd>Enter</kbd> / <kbd>单击</kbd> | 打开选中的文件或文件夹 |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> / <kbd>单击</kbd> | 打开文件所在文件夹 |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | 在 Everything 客户端中打开当前搜索 |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>C</kbd> | 复制文件完整路径到剪贴板 |
| <kbd>Alt</kbd> + <kbd>Enter</kbd> | 查看文件属性 |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>Enter</kbd> | 以管理员身份运行选中的程序 |
| <kbd>Shift</kbd> + <kbd>右键</kbd> | 打开原生系统右键上下文菜单 |
| <kbd>Tab</kbd> / <kbd>Shift</kbd> + <kbd>Tab</kbd> | 循环切换搜索过滤器 |
| <kbd>Ctrl</kbd> + <kbd>0-9</kbd> | 依序号快速选择指定过滤器 |
| <kbd>Space</kbd> | 在 QuickLook 中即时预览文件 |
| <kbd>Esc</kbd> | 关闭搜索窗口 |

---

## 📦 安装与快速使用（绿色免安装）

### 环境要求
- **操作系统**：Windows 10 或 Windows 11（64位）
- **运行环境**：[.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)（LTS）
- **后台服务**：[Everything](https://www.voidtools.com/) ≥ 1.4.1（x64）已安装并在后台运行

### 快速上手
1. 前往 [GitHub Releases](https://github.com/Crucialmer/EverythingTB/releases/latest) 下载唯一的绿色免安装包 **`EverythingTB.zip`**。
2. 解压到任意你喜欢的目录（如 `D:\Tools\EverythingTB`）。
3. 双击运行 **`EverythingTB.exe`**，程序将直接静默驻留于任务栏托盘。
4. 按下全局快捷键 <kbd>Win</kbd> + <kbd>Alt</kbd> + <kbd>S</kbd>，即刻体验极致搜索！
5. **纯绿色承诺**：所有的个性化配置、自定义规则及运行日志均保存在本地 `./Config/` 目录下，绿色无污染，迁移换机直接打包带走。

---

## 📄 开源许可

本项目基于 [MIT License](LICENSE.txt) 许可协议开源发布。
特别感谢原开源项目 [EverythingToolbar](https://github.com/srwi/EverythingToolbar) 及 [voidtools Everything](https://www.voidtools.com/) 提供的卓越基础。
