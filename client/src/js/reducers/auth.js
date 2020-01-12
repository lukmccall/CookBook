import { LOGIN, USER_DATA_WAS_LOADED } from '../actions/types';

export const auth = (state = {}, action) => {
  switch (action.type) {
    case LOGIN:
      return {
        ...state,
        logged: action.user,
      };
    case USER_DATA_WAS_LOADED:
      return {
        ...state,
        user: action.userInfo,
      };
    default:
      return state;
  }
};
