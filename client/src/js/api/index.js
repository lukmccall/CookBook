import { Client } from './client';
import { AuthControllerWrapper, TokenToAuth } from './wrappers';

export const ApiClient = new Client();
export { AuthControllerWrapper, TokenToAuth };
