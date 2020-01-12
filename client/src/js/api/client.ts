import { RegisterRequest, AuthSuccessResponse, AuthFailedResponse, ValidationFailedResponse, LoginRequest, LogoutRequest, RefreshRequest, ProblemDetails, RecipesPriceBreakdownResponse, RecipeIngredientsResponse, IngredientsRequest, RecipeResponse, RecipeInstructionResponse, UpdateCurrentUserRequest, ChangeCurrentUserPasswordRequest, WidgetResponse } from "./types";
export class Client {
    baseUrl = "http://localhost";

    async register(body: RegisterRequest | undefined ): Promise<AuthSuccessResponse> {
        let _url = this.baseUrl + "/api/v1/auth/register?";
        let _headers: {[key: string]: string} = {} ; 
       
        let _body = JSON.stringify(body);  
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            body: _body,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 200) {
            let _data200 = AuthSuccessResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
        if (_response.status === 400) {
            let _data400 = AuthFailedResponse.fromResponse(await _response.json()); 
            throw _data400;
        }
        if (_response.status === 422) {
            let _data422 = ValidationFailedResponse.fromResponse(await _response.json()); 
            throw _data422;
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async login(body: LoginRequest | undefined ): Promise<AuthSuccessResponse> {
        let _url = this.baseUrl + "/api/v1/auth/login?";
        let _headers: {[key: string]: string} = {} ; 
       
        let _body = JSON.stringify(body);  
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            body: _body,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 200) {
            let _data200 = AuthSuccessResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
        if (_response.status === 400) {
            let _data400 = AuthFailedResponse.fromResponse(await _response.json()); 
            throw _data400;
        }
        if (_response.status === 422) {
            let _data422 = ValidationFailedResponse.fromResponse(await _response.json()); 
            throw _data422;
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async logout(body: LogoutRequest | undefined ): Promise<void> {
        let _url = this.baseUrl + "/api/v1/auth/logout?";
        let _headers: {[key: string]: string} = {} ; 
       
        let _body = JSON.stringify(body);  
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            body: _body,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 400) {
            let _data400 = AuthFailedResponse.fromResponse(await _response.json()); 
            throw _data400;
        }
        if (_response.status === 422) {
            let _data422 = ValidationFailedResponse.fromResponse(await _response.json()); 
            throw _data422;
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async refresh(body: RefreshRequest | undefined ): Promise<AuthSuccessResponse> {
        let _url = this.baseUrl + "/api/v1/auth/refresh?";
        let _headers: {[key: string]: string} = {} ; 
       
        let _body = JSON.stringify(body);  
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            body: _body,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 200) {
            let _data200 = AuthSuccessResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
        if (_response.status === 400) {
            let _data400 = AuthFailedResponse.fromResponse(await _response.json()); 
            throw _data400;
        }
        if (_response.status === 422) {
            let _data422 = ValidationFailedResponse.fromResponse(await _response.json()); 
            throw _data422;
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async getRecipePriceBreakdown(id: number): Promise<RecipesPriceBreakdownResponse> {
        let _url = this.baseUrl + "/recipePriceBreakdown/{id}?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (id === undefined || id === null) {    
            throw new Error("`id` is required." );    
        }    
        _url = _url.replace("{id}", encodeURIComponent("" +  id));    
          
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 404) {
            let _data404 = ProblemDetails.fromResponse(await _response.json()); 
            throw _data404;
        }
        if (_response.status === 200) {
            let _data200 = RecipesPriceBreakdownResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async getRecipeIngredients(id: number): Promise<RecipeIngredientsResponse> {
        let _url = this.baseUrl + "/recipeIngredients/{id}?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (id === undefined || id === null) {    
            throw new Error("`id` is required." );    
        }    
        _url = _url.replace("{id}", encodeURIComponent("" +  id));    
          
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 404) {
            let _data404 = ProblemDetails.fromResponse(await _response.json()); 
            throw _data404;
        }
        if (_response.status === 200) {
            let _data200 = RecipeIngredientsResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async searchByIngredients(body: IngredientsRequest | undefined ): Promise<Array<RecipeResponse>> {
        let _url = this.baseUrl + "/searchByIngredients?";
        let _headers: {[key: string]: string} = {} ; 
       
        let _body = JSON.stringify(body);  
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            body: _body,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 404) {
            let _data404 = ProblemDetails.fromResponse(await _response.json()); 
            throw _data404;
        }
        if (_response.status === 200) {
            let _data200 = [] as any; 
            for (let _item of await _response.json()) { 
                _data200.push(_item); 
            } 
            return _data200; 
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async recipeInstructions(id: number, stepBreakdown: boolean| undefined): Promise<Array<RecipeInstructionResponse>> {
        let _url = this.baseUrl + "/recipeInstructions/{id}?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (id === undefined || id === null) {    
            throw new Error("`id` is required." );    
        }    
        _url = _url.replace("{id}", encodeURIComponent("" +  id));    
            
        if (stepBreakdown !== undefined) {    
            _url += "stepBreakdown=" + encodeURIComponent("" + stepBreakdown) + "&";     
        }    
          
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 404) {
            let _data404 = ProblemDetails.fromResponse(await _response.json()); 
            throw _data404;
        }
        if (_response.status === 200) {
            let _data200 = [] as any; 
            for (let _item of await _response.json()) { 
                _data200.push(_item); 
            } 
            return _data200; 
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async geCurrentUser(Authorization: string): Promise<void> {
        let _url = this.baseUrl + "/api/v1/users/me/get?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (Authorization === undefined || Authorization === null) {    
            throw new Error("`Authorization` is required." );    
        }    
        if (Authorization === "") {    
            throw new Error("`Authorization` cound't be empty." );    
        }    
        _headers["Authorization"] = Authorization;     
          
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async updateCurrentUser(Authorization: string, body: UpdateCurrentUserRequest | undefined ): Promise<void> {
        let _url = this.baseUrl + "/api/v1/users/me/update?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (Authorization === undefined || Authorization === null) {    
            throw new Error("`Authorization` is required." );    
        }    
        if (Authorization === "") {    
            throw new Error("`Authorization` cound't be empty." );    
        }    
        _headers["Authorization"] = Authorization;     
            
        let _body = JSON.stringify(body);  
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            body: _body,
            method: "PATCH",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async changeCurrentUserPassword(Authorization: string, body: ChangeCurrentUserPasswordRequest | undefined ): Promise<void> {
        let _url = this.baseUrl + "/api/v1/user/me/changePassword?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (Authorization === undefined || Authorization === null) {    
            throw new Error("`Authorization` is required." );    
        }    
        if (Authorization === "") {    
            throw new Error("`Authorization` cound't be empty." );    
        }    
        _headers["Authorization"] = Authorization;     
            
        let _body = JSON.stringify(body);  
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            body: _body,
            method: "PATCH",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async recipeVisualization(id: number, defaultCss: boolean| undefined): Promise<WidgetResponse> {
        let _url = this.baseUrl + "/recipeVisualization/{id}?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (id === undefined || id === null) {    
            throw new Error("`id` is required." );    
        }    
        _url = _url.replace("{id}", encodeURIComponent("" +  id));    
            
        if (defaultCss !== undefined) {    
            _url += "defaultCss=" + encodeURIComponent("" + defaultCss) + "&";     
        }    
          
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 200) {
            let _data200 = WidgetResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
        if (_response.status === 404) {
            let _data404 = ProblemDetails.fromResponse(await _response.json()); 
            throw _data404;
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async equipmentVisualization(id: number, defaultCss: boolean| undefined): Promise<WidgetResponse> {
        let _url = this.baseUrl + "/equipmentVisualization/{id}?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (id === undefined || id === null) {    
            throw new Error("`id` is required." );    
        }    
        _url = _url.replace("{id}", encodeURIComponent("" +  id));    
            
        if (defaultCss !== undefined) {    
            _url += "defaultCss=" + encodeURIComponent("" + defaultCss) + "&";     
        }    
          
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 200) {
            let _data200 = WidgetResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
        if (_response.status === 404) {
            let _data404 = ProblemDetails.fromResponse(await _response.json()); 
            throw _data404;
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async priceBreakdownVisualization(id: number, defaultCss: boolean| undefined): Promise<WidgetResponse> {
        let _url = this.baseUrl + "/priceBreakdownVisualization/{id}?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (id === undefined || id === null) {    
            throw new Error("`id` is required." );    
        }    
        _url = _url.replace("{id}", encodeURIComponent("" +  id));    
            
        if (defaultCss !== undefined) {    
            _url += "defaultCss=" + encodeURIComponent("" + defaultCss) + "&";     
        }    
          
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 200) {
            let _data200 = WidgetResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
        if (_response.status === 404) {
            let _data404 = ProblemDetails.fromResponse(await _response.json()); 
            throw _data404;
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

    async nutrionVisualization(id: number, defaultCss: boolean| undefined): Promise<WidgetResponse> {
        let _url = this.baseUrl + "/nutrionVisualization/{id}?";
        let _headers: {[key: string]: string} = {} ; 
       
        if (id === undefined || id === null) {    
            throw new Error("`id` is required." );    
        }    
        _url = _url.replace("{id}", encodeURIComponent("" +  id));    
            
        if (defaultCss !== undefined) {    
            _url += "defaultCss=" + encodeURIComponent("" + defaultCss) + "&";     
        }    
          
        _url = _url.replace(/[?&]$/, "");
    
        let _options = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json",
                ..._headers
            }
        };
    
        let _response = await fetch(_url, _options);
    
        if (_response.status === 200) {
            let _data200 = WidgetResponse.fromResponse(await _response.json()); 
            return _data200; 
        }
        if (_response.status === 404) {
            let _data404 = ProblemDetails.fromResponse(await _response.json()); 
            throw _data404;
        }
    
        // handling undefinded response
        if (_response.status !== 200 && _response.status !== 204) {
            throw new Error("An unexpected server error occurred.");
        }
    
        return null;
    }

}
