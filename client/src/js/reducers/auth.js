import { LOGIN } from '../actions/types';

export const auth = (state = {}, action) => {
  switch (action.type) {
    case LOGIN:
      return action.user;
    default:
      return state;
  }
};
