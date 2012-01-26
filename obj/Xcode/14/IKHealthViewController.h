// WARNING
// This file has been generated automatically by MonoDevelop to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <UIKit/UIKit.h>
#import <Foundation/Foundation.h>
#import <CoreGraphics/CoreGraphics.h>

#import "IKTextField.h"

@interface IKHealthViewController : UIViewController {
	UIButton *__loginButton;
	IKTextField *__usernameField;
	IKTextField *__passwordField;
}

@property (nonatomic, retain) IBOutlet UIButton *_loginButton;

@property (nonatomic, retain) IBOutlet IKTextField *_usernameField;

@property (nonatomic, retain) IBOutlet IKTextField *_passwordField;

- (IBAction)textFieldDidBeginEditing:(id)sender;

- (IBAction)textFieldDidEndEditing:(id)sender;

@end
