param([int]$Minutes = 37, [string]$Until, [int]$Total)
$Host.UI.RawUI.WindowTitle = "Bis zum Essen"
[console]::OutputEncoding = [System.Text.Encoding]::UTF8
$full  = [string][char]0x25CF   # filled bobble
$small = [string][char]0x2022   # small dot for minutes already gone
if ($Until) { $end = [datetime]$Until } else { $end = (Get-Date).AddMinutes($Minutes) }
if (-not $Total) { $Total = [math]::Round(($end - (Get-Date)).TotalMinutes) }
while ($true) {
    $left = $end - (Get-Date)
    if ($left.TotalSeconds -le 1) { break }
    $min = [math]::Round($left.TotalMinutes)
    $gone = [math]::Max(0, $Total - $min)
    Clear-Host
    Write-Host ""
    Write-Host "   Noch $min Minuten bis zum Essen" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "   " -NoNewline
    Write-Host ((@($full) * $min) -join " ") -ForegroundColor Yellow -NoNewline
    if ($gone -gt 0) { Write-Host (" " + ((@($small) * $gone) -join " ")) -ForegroundColor DarkGray -NoNewline }
    Write-Host ""
    # sleep until the next full minute mark
    $wait = $left.TotalSeconds - ($min - 1) * 60
    if ($wait -lt 1) { $wait = 60 }
    Start-Sleep -Milliseconds ([int]($wait * 1000))
}
Clear-Host
Write-Host ""
Write-Host "   ESSEN!" -ForegroundColor Green
[console]::Beep(880, 400); [console]::Beep(880, 400); [console]::Beep(1100, 600)
Read-Host "   (Enter zum Schliessen)"
