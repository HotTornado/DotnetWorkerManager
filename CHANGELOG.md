# Changelog

All notable changes to **DBK Custom Service Manager** will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [1.0.0] - 2026-09-05

### Added
- **Tracked Service Filtering**:
  - `services.json` configuration to monitor only user-selected .NET APIs and Workers instead of all OS services.
  - Non-blocking `FileShare.ReadWrite` reading with automatic fallback retries.
  - Real-time `FileSystemWatcher` that reloads tracked services when `services.json` is modified externally.
- **Main Dashboard (`MainPage`)**:
  - `DataGridView` displaying Name, Executable Full Path, and Current Status badges (Running, Stopped, Pending, Unknown).
  - Registry-based `ImagePath` resolution (`HKLM\SYSTEM\CurrentControlSet\Services\{name}\ImagePath`) with quote and argument stripping.
  - Custom-painted action buttons with distinct colors:
    - **Start** (Green `#28a745`)
    - **Restart** (Yellow/Amber `#ffc107`)
    - **Stop** (Red `#dc3545`)
    - **Show Logs** (Blue `#0d6efd`)
  - Asynchronous service state operations via `ServiceController` preventing UI freezes.
  - Background auto-refresh timer (4-second interval) keeping statuses synchronized.
  - File and Services menu strip items for editing and reloading configuration.
- **Event Viewer Log Inspector (`LogPage`)**:
  - Queries Windows Event Viewer (`Application` and `System` channels) for records matching the worker.
  - Default **last 60 seconds** time filter with options for 5m, 15m, and 1h.
  - Event grid with timestamp, colored severity badges, event ID, source, and message.
  - Lower detail panel rendering complete messages, exception details, and raw XML.
  - Live auto-refresh toggle (3-second polling) and "Copy All" clipboard export.
- **Worker Registration Wizard (`RegisterWorkerForm`)**:
  - GUI to register any `.exe` as a Windows Service using `sc.exe create`.
  - Executable file browser with automatic service name inference.
  - Startup type configuration (Automatic, Manual, Disabled) and description field.
  - Automatic addition to `services.json` and optional immediate service start.
