import { LOGIN } from './types';

export const userLogged = user => ({
  type: LOGIN,
  user,
});
