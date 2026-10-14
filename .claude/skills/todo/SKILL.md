---
name: todo
description: Add a task to the countdown task list in NEXT.md. Use when the user types /todo, or asks to put something on the to-do list / next steps for later.
argument-hint: <what to do>   (start with "!" to put it at the top)
---

Add this task to the **To do** section of `NEXT.md` in the repo root:

$ARGUMENTS

Steps:
1. Read `NEXT.md` fresh (the user and other sessions edit it too). Never rewrite it from an older copy.
2. Turn the task into one line `- [ ] <task>`. Keep the user's wording and language; only fix obvious typos. If it contains several separate wishes, make one line per wish.
3. If the text starts with `!`, drop the `!` and insert the line(s) at the top of **To do** (urgent). Otherwise add them at the end of **To do**.
4. Remove an empty placeholder line `- [ ] ` if there is one. Change nothing else in the file.
5. Commit only this file right away: `git add NEXT.md && git commit -m "NEXT.md: add <short task>"` (with the attribution lines the session requires). No `git add -A`.
6. Answer in one or two short lines: what was added and at which position. Do not start working on it; `/next` does that.
