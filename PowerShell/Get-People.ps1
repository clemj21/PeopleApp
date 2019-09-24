param(
  [string]$server = "http://localhost:64884"
)

$url = "{0}/api/people" -f $server

Invoke-RestMethod -Method Get -Uri $url
$json = $response | ConvertTo-Json
