export const environment = {
  production: true,
  apiReadRoot: '#{SpotifyBrowserFrontend.apiReadRoot}#',
  apiWriteRoot: '#{SpotifyBrowserFrontend.apiWriteRoot}#',
  userApiReadRoot: '#{SpotifyBrowserFrontend.userApiReadRoot}#',
  userApiWriteRoot: '#{SpotifyBrowserFrontend.userApiWriteRoot}#',
  stsAuthority: '#{SpotifyBrowserFrontend.stsAuthority}#',
  clientRoot: '#{SpotifyBrowserFrontend.clientRoot}#',
  appInsights: {
    instrumentationKey: '#{SpotifyBrowserFrontend.appInsights.instrumentationKey}#'
  }
};
