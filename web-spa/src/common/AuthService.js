import Oidc from 'oidc-client';

//http://docker.for.win.localhost:5007
const DEVELOPMENT_URL = "http://docker.for.win.localhost:5007"
const config = {
    userStore: new Oidc.WebStorageStateStore({store: window.localStorage}),
    authority: "http://docker.for.win.localhost:5001",
    client_id: "js",
    redirect_uri: DEVELOPMENT_URL + "/#/callback",
    response_type: "code",
    scope:"openid profile api1",
    post_logout_redirect_uri : DEVELOPMENT_URL,

}

const mgr = new Oidc.UserManager(config);
export default mgr;