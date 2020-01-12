import { LOGIN, USER_DATA_WAS_LOADED } from './types';
import { ApiClient } from '../api';

const currentUserDataWasLoaded = userInfo => ({
  type: USER_DATA_WAS_LOADED,
  userInfo,
});

export const userLogged = user => ({
  type: LOGIN,
  user,
});

export const getUserData = autorizationsString => dispach => {
  ApiClient.geCurrentUser(autorizationsString)
    .then(userInfo => dispach(currentUserDataWasLoaded(userInfo)))
    .catch(e => {});
};
