# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project

Unity 6 (6000.4.6f1) traffic light simulation using Universal Render Pipeline (URP). Single scene: `Assets/Scenes/SampleScene.unity`.

## Skills

進行任何修改前，請先閱讀以下 skill 檔案：

- `.codex/skills/architecture-mvp.md` — MVP 架構規則
- `.codex/skills/naming.md` — 命名規則
- `.codex/skills/git-workflow.md` — Git 提交與分支規範

## Architecture

Current code is View-only (Presenter/Model not yet introduced). `TrafficLightView` drives its own coroutine loop; this is a temporary state before the Presenter layer is added.

### UI System

- `UIBase` — base class for all UI screens; `Show()`/`Hide()` toggle `gameObject.SetActive`.
- `UIManager : Singleton<UIManager>` — opens UI panels by type. Loads prefabs from `Resources/Prefabs/UI/<TypeName>` on first open; caches them in a `Dictionary<Type, UIBase>`.
- `Singleton<T>` — auto-creates a `DontDestroyOnLoad` GameObject if none exists in the scene.

### TrafficLight

- `TrafficLightView : UIBase` — cycles Red → Yellow → Green using a coroutine; each phase displays a countdown via `LightView`.
- `LightView` — leaf component; wraps an `Image` (color) and `TMP_Text` (seconds remaining).

