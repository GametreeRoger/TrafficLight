# Git Workflow

## Commit Rules

- Commit after meaningful units of work
- Keep commits focused
- Do not mix unrelated changes
- Co-authored-by: AI Agent

## Commit Style

Use Conventional Commits.

Examples:

feat: add inventory presenter
fix: resolve null reference in chat ui
perf: reduce scroll allocation


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