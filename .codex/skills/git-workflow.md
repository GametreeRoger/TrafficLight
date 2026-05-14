# Git Workflow

## Commit Rules

- Commit after meaningful units of work
- Keep commits focused
- Do not mix unrelated changes

## Commit Style

Use Conventional Commits.

Examples:

feat: add inventory presenter
fix: resolve null reference in chat ui
perf: reduce scroll allocation
Co-authored-by: Codex <noreply@openai.com>

## Push Rules

Never push to main.

Push only when:

- tests pass
- user explicitly requests

## Unity Rules

Do not commit:

- Library/
- Temp/
- Obj/

Avoid committing accidental scene changes.