param(
  [string]$server = "http://localhost:64884",
  $body
)

$url = "{0}/api/people" -f $server

Invoke-RestMethod -Method Post -Uri $url -Body $body
$json = $response | ConvertTo-Json