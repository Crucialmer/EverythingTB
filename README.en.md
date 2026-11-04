_Languages / 语言: [English](README.en.md), [简体中文](README.md)_

# <img src="EverythingToolbar/Images/AppIcon.ico" width="24"> EverythingTB

<a href="https://github.com/Crucialmer/EverythingTB/releases/latest"><img src="https://img.shields.io/github/v/release/Crucialmer/EverythingTB?color=blue" height="25" /></a>
<a href="https://github.com/Crucialmer/EverythingTB/releases/latest"><img src="https://img.shields.io/github/downloads/Crucialmer/EverythingTB/total?color=critical" height="25" /></a>
<a href="https://dotnet.microsoft.com/en-us/download/dotnet/10.0"><img src="https://img.shields.io/badge/.NET-10.0%20LTS-purple.svg" height="25" /></a>

Instant file search integration for Windows powered by [Everything](https://www.voidtools.com/).

## 🚀 EverythingTB v1.7.9 Highlights

- **Taskbar Setup Assistant Defaults to Right Option (Taskbar Search Box)**:
  - Fresh installations will now display the Taskbar Setup Assistant (choose between pinned taskbar icon or taskbar search box), while the search interface remains completely silent without unwanted popups.

- **Default Sort by Run Count (Descending)**:
  - Search results are sorted by **Run Count (Descending)** out of the box, putting your most frequently launched apps and files directly at your fingertips.

- **List Focus Behavior Defaults to "Clamp" (Stop at Borders)**:
  - Arrow key navigation in search results now stops cleanly at the top and bottom boundaries rather than cycling unexpectedly.

- **Default Result Omissions Synchronized**:
  - Automatically respects Everything 1.5 result omissions and exclusions by default.

- **Default Shortcut: `Alt + S`**:
  - Global summon shortcut is `Alt + S`, avoiding Windows key conflicts and enabling effortless one-hand summoning.

- **Refined Taskbar Date Widget Corner Radius**:
  - The corner radius of the taskbar date & weekday capsule has been refined to a subtle 6px, creating a crisp, sophisticated balance with the full-pill search box.

- **Dynamic Font Weight Engine (Full 100~900 Spectrum for PingFang & More)**:
  - Fully supports all 9 weights (100 Ultralight to 900 Black) for **PingFang SC** (苹方), Source Han Sans, and variable fonts.

- **Pure Pristine Architecture**:
  - Single executable distribution package **`EverythingTB.exe`** inside **`EverythingTB.zip`**, isolated `./Config/` folder for 100% portable green usage.

- **macOS 26 Design Aesthetic**:
  - Floating translucent glass card with 14px rounded corners and 1px luminous border.

---

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/demo.gif" alt="EverythingTB showcase" width="100%">

## ✨ Features

EverythingTB is an instant search integration powered by [Everything](https://www.voidtools.com/).

### Taskbar Integration
EverythingTB can be used as a replacement for the Windows search bar or as an icon. Switching between the two modes is done with one click in the preferences.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/taskbar_modes.png" alt="Taskbar search modes" width="80%">

### Light & Dark Theme
EverythingTB matches your Windows design. It uses your system accent color and supports light and dark themes out of the box.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/fast.png" alt="Light and dark theme" width="80%">

### Everything Filters
Built-in filters include audio, documents, executables, folders, pictures, and video. You may also use your custom filters defined in Everything.

<img src="https://raw.githubusercontent.com/srwi/EverythingToolbar/develop/.github/images/filters.png" alt="Custom filter options" width="80%">

### Quick Toggles
Quickly toggle search options like match case, match whole words, match path, or regular expressions (regex) to find your files with precision.

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
| <kbd>Alt</kbd> + <kbd>S</kbd> | Focus search box (customizable) |

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
