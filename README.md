_Read in other languages: [English](README.md), [中文](README.zh-CN.md)_

# <img src="EverythingToolbar/Images/AppIcon.ico" width="24"> EverythingTB

<a href="https://github.com/Crucialmer/EverythingTB/releases/latest"><img src="https://img.shields.io/github/v/release/Crucialmer/EverythingTB?color=blue" height="25" /></a>
<a href="https://github.com/Crucialmer/EverythingTB/releases/latest"><img src="https://img.shields.io/github/downloads/Crucialmer/EverythingTB/total?color=critical" height="25" /></a>
<a href="https://dotnet.microsoft.com/en-us/download/dotnet/10.0"><img src="https://img.shields.io/badge/.NET-10.0%20LTS-purple.svg" height="25" /></a>

Instant file search integration for Windows powered by [Everything](https://www.voidtools.com/).

## 🚀 EverythingTB v1.7.4 Highlights

- **Zero-Popup Silent Startup (Clean Direct Launch)**:
  - Eliminated unwanted automatic popup windows on launch; the application now boots directly and silently into the system tray.
  - Background offscreen pre-warming delivers instant responsiveness when summoned via global hotkey (`Win+Alt+S`) or tray icon.

- **Pure Pristine Architecture (Zero Legacy Overhead)**:
  - Completely stripped all backward-compatibility stubs and legacy batch scripts; distribution package now contains solely the native **`EverythingTB.exe`**.
  - System tray tooltip, mutex identifiers, and auto-restart pipelines updated strictly to EverythingTB branding.
  - Search history now fully portable under `Config/history.xml` for 100% self-contained green deployment.

- **Unified About Page & Repository Links**:
  - Banner title and all community/FAQ hyperlinks refreshed to point directly to `Crucialmer/EverythingTB`.

- **Hide Empty Search Enabled by Default (Spotlight Minimal Experience)**:
  - Settings → Search → Behavior → `Hide empty search` is now enabled out-of-the-box.
  - Opening search displays a clean, focused search card without dumping unfiltered files, matching modern macOS Spotlight elegance.

- **Complete Brand Evolution: EverythingTB**:
  - The project, release package, application UI, and updater have evolved into **EverythingTB**.
  - Distributed as a pure portable package: **`EverythingTB.zip`**, directly run `EverythingTB.exe`.

- **macOS 26 Design Aesthetic**:
  - **Floating Translucent Glass Card**: Search window crafted with 14px smooth rounded corners and a subtle 1px luminous translucent border outline, delivering a floating frosted acrylic aesthetic.
  - **Pill-style Preview Pane**: Refined sidebar border and smooth padding seamlessly integrating with the search view.
  - **macOS 26 & Fluent Typography Hierarchy**: Global default font stack prioritizing `Segoe UI Variable Text` with smooth fallback to `Microsoft YaHei UI`, offering crystal-clear Latin numbers and elegant Chinese typography.
  - **Spotlight Row Selection & Accent Highlight**: 8px rounded selection capsules, Apple Vibrant Blue search match highlights (`#2997FF` / `#0071E3`), and accent indicators.
  - **Taskbar Date & Weekday Pill Widget**: Quick glance calendar and weekday pill widget on Windows 11 taskbar with zero-overhead layout caching.

- **Deep Code Optimization & Zero-Impact Execution**:
  - **Optimized UI Invalidation & Timer Cycles**: Reduced background timer overhead and cached string layouts to completely prevent unnecessary layout passes.
  - **Native Per-Monitor V2 & 8K Display Resolution**: Crystal-clear scaling from 100% to 500%+ with Shell Jumbo (256×256) icons.
  - **Direct In-App Auto-Update**: Silent updates without external browser redirection directly from `Crucialmer/EverythingTB`. Portable `./Config` directory is completely protected.
  - **100% Pure Portable Architecture**: Zero registry writes, zero `%APPDATA%` pollution.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/demo.gif" alt="EverythingTB in action" width="80%">

## 🌟 Features

### Taskbar Integration & macOS 26 Date Widget
EverythingTB sits right on your taskbar with an optional macOS 26 style Date & Day of Week pill widget next to the search box, bringing convenient calendar access and date visibility to Windows 11.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/taskbar_modes.png" alt="Taskbar search box and search icon" width="80%">

### In-App Direct Auto-Update
Check, download, and install updates directly within the application without being redirected to GitHub in an external browser. All user data in `./Config/` is safely preserved across updates.

### Light & Dark Themes
EverythingTB seamlessly blends into Windows 10 and 11, automatically adjusting to your system theme with macOS 26 vibrant accent highlights.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/fast.png" alt="Light and dark themes" width="80%">

### Custom Search Filters
EverythingTB includes common search filters out of the box. For advanced users, it can synchronize with Everything's custom filters, giving you complete control over your search experience. Enable this feature by checking **Use Everything filters** in the EverythingTB's **Filters** settings.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/flexible.png" alt="Custom search filters" width="80%">

### Quick Search Options
Easily toggle search flags (match case, whole word, match path, and regex) to find your files with precision.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/on_point.png" alt="Quick toggles" width="80%">

### Regex-based File Operations
Create custom **Open with** actions in **Settings** → **Custom Actions**. Enabling **Apply rules conditionally** allows automatic command execution based on file types and regex patterns.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/custom_actions.png" alt="Custom action options" width="80%">

### Compatibility & Ultra-High Resolution
EverythingTB runs smoothly on Windows 10 and Windows 11, with native support for 8K/4K displays and any DPI scaling factor.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/compatible.png" alt="Windows 10 screenshot" width="80%">

### Keyboard Shortcuts

| Shortcut | Description |
|---|---|
| <kbd>↑</kbd> / <kbd>↓</kbd> | Navigate search results |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> / <kbd>↓</kbd> | Navigate search history (if enabled) |
| <kbd>Enter</kbd> / <kbd>Click</kbd> | Open file or folder |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> / <kbd>Click</kbd> | Open path |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> / <kbd>Click</kbd> | Open in Everything |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>C</kbd> | Copy full path to clipboard |
| <kbd>Alt</kbd> + <kbd>Enter</kbd> / <kbd>Click</kbd> | Open properties |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>Enter</kbd> / <kbd>Click</kbd> | Run as administrator |
| <kbd>Shift</kbd> + <kbd>Right-click</kbd> | Open system context menu |
| (<kbd>Shift</kbd> +) <kbd>Tab</kbd> | Cycle through filters |
| <kbd>Ctrl</kbd> + <kbd>0-9</kbd> | Select filter by index |
| <kbd>Space</kbd> | Preview file in QuickLook |
| <kbd>Win</kbd> + <kbd>Alt</kbd> + <kbd>S</kbd> | Focus search box (customizable) |

## 📦 Installation & Portable Usage

### Requirements
- Windows 10 or Windows 11
- [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [Everything](https://www.voidtools.com) ≥ 1.4.1 (x64) running in the background

### Quick Start (Portable)
1. Download `EverythingTB.zip` from [GitHub Releases](https://github.com/Crucialmer/EverythingTB/releases/latest).
2. Extract to any folder you prefer.
3. Directly run `EverythingTB.exe`.
4. Settings, rules, and logs are isolated inside the `./Config/` directory.
