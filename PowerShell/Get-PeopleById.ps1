param(
  [string]$server = "http://localhost:64884",
  [string]$id = "1"
)

$url = "{0}/api/people/{1}" -f $server, $id

Invoke-RestMethod -Method Get -Uri $url
$json = $response | ConvertTo-Json