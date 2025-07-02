# GPU Temperature Monitor (WinForms)

An extensible GPU diagnostics tool built in C#. Designed to be lean, responsive, and modular — perfect for real-time monitoring of GPU temperature and fan RPM. I've leveraged the OpenHardwareMonitor library to quickly query the computer's hardware.

This project began as a personal build for my first personal gaming laptop. I wanted fast access to vital GPU and fan data without relying on bulky third-party tools. It’s also a good example of clean architecture and async-safe UI design for responsiveness. It runs quietly in the background, tracking key vitals like temperature and RPM, with plans to expand into full diagnostic and benchmarking support. Not all features are implemented as yet. Check back for future releases.

## Features

- 🌡️ Real-time GPU temperature monitoring
- 🌀 GPU fan RPM tracking
- ✅ Async-safe UI updates using `Task.Run` and `await`
- 🧱 Modular sensor logic via a static service class
- 🚦 Alert threshold for high temperature
- 💬 Status feedback on screen
- 🛠️ Easy to extend — with architecture that invites customization and experimentation

I built this as a learning tool and a functional showcase — it reflects how I approach clean code, modular design, and responsiveness. Feel free to explore the repo or reach out if you’d like to discuss improvements or extensions.
