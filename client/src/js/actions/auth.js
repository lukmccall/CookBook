import { LOGIN, USER_DATA_WAS_LOADED, LOGOUT } from './types';
import { ApiClient } from '../api';

const currentUserDataWasLoaded = userInfo => ({
  type: USER_DATA_WAS_LOADED,
  userInfo,
});

const logouted = () => ({
  type: LOGOUT,
});

export const userLogged = user => ({
  type: LOGIN,
  user,
});

export const getUserData = autorizationString => dispach => {
  ApiClient.geCurrentUser(autorizationString)
    .then(userInfo => dispach(currentUserDataWasLoaded(userInfo)))
    .catch(e => {});
};

export const logout = token => dispach => {
  ApiClient.logout({ token })
    .then(() => dispach(logouted()))
    .catch(e => {});
};
