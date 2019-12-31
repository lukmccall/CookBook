import { Client } from './client';
import { AuthControllerWrapper } from './wrappers';

export const URL = 'https://localhost:5001';

export const ApiClient = new Client(URL);

export { AuthControllerWrapper };
