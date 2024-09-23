'use client';
import React from "react";
import { Avatar, AvatarFallback, AvatarImage } from "../components/ui/avatar";
import { Card, CardContent, CardFooter, CardHeader } from "../components/ui/card";
import { Button } from "../components/ui/button";
import { Input } from "../components/ui/input";
import dynamic from 'next/dynamic';
import { HeartIcon, MessageCircleIcon, BookmarkIcon } from "lucide-react";
import DOMPurify from 'dompurify';
import Popup from "reactjs-popup";
import 'reactjs-popup/dist/index.css';
const MonacoEditor = dynamic(() => import('@monaco-editor/react'), { ssr: false });
const Post = ({ post, onLike, onSave, onShowComments, onAddComment}) => {

  const [lang, setLang] = React.useState('c');
  const [isPopupOpen, setIsPopupOpen] = React.useState(false);
  const togglePopup = () => {
    setIsPopupOpen(!isPopupOpen);
  }
  const createMarkup = (content) => {
    const sanitizedContent = DOMPurify.sanitize(content);
    return { __html: sanitizedContent };
  };
  return (
    <Card key={post.id}>
      <CardHeader className="flex flex-row items-center gap-4">
        <Avatar>
          <AvatarImage src={post.avatar} alt={post.author} />
          <AvatarFallback>{post.author[0]}</AvatarFallback>
        </Avatar>
        <div>
          <h3 className="text-lg font-semibold">{post.author}</h3>
          <p className="text-sm text-gray-500">Posted 2 hours ago</p>
        </div>
      </CardHeader>
      <CardContent className="space-y-4">
        <h2 className="text-xl font-semibold">{post.title}</h2>

        {/* Render sanitized content with proper styling */}
        {post.content && (
          <div className="post-content" dangerouslySetInnerHTML={createMarkup(post.content)} />
        )}

        {post.code && (
          <pre className="bg-gray-100 p-4 rounded-md overflow-x-auto">
            <MonacoEditor
              height="200px"
              language={post.lang}
              value={post.code}
              options={{ readOnly: true }}
            />
          </pre>
        )}
        {post.images.length > 0 && (
          <div className="grid grid-cols-3 gap-2">
            {post.images.map((image, index) => (
              <div key={index} className="relative aspect-w-1 aspect-h-1">
                <img src={image} alt="Post" className="object-cover w-full h-full rounded-md" />
                <div className="absolute inset-0 flex items-center justify-center gap-2 opacity-0 hover:opacity-100 bg-black bg-opacity-50 rounded-md">
                  <Button variant="ghost" onClick={togglePopup}>
                    view
                  </Button>
                  <Popup open={isPopupOpen} onClose={togglePopup}>
                    <img src={image} alt="Post" className="object-cover w-full h-full rounded-md img-card" />
                  </Popup>

                </div>
              </div>
            ))}

          </div>
        )}
      </CardContent>
      <CardFooter className="flex justify-between">
        <div className="flex space-x-2">
          <Button variant="ghost" onClick={() => onLike(post.id)}>
            <HeartIcon className={`w-5 h-5 ${post.liked ? 'text-red-500 fill-red-500' : 'text-gray-500'}`} />
            <span>{post.likes} Likes</span>
          </Button>
          <Button variant="ghost" onClick={() => onShowComments(post.id)}>
            <MessageCircleIcon className="w-5 h-5" />
            <span>{post.comments.length} Comments</span>
          </Button>
        </div>
        <Button variant="ghost" onClick={() => onSave(post.id)}>
          <BookmarkIcon className={`w-5 h-5 ${post.saved ? 'text-blue-500 fill-blue-500' : 'text-gray-500'}`} />
          <span>{post.saved ? 'Saved' : 'Save'}</span>
        </Button>
      </CardFooter>
      {/* Comments Section */}
      {post.showComments && (
        <CardContent>
          <div className="space-y-4">
            {post.comments.map(comment => (
              <div key={comment.id} className="flex items-start gap-4">
                <Avatar className="w-8 h-8">
                  <AvatarFallback>{comment.author[0]}</AvatarFallback>
                </Avatar>
                <div className="flex-1">
                  <p className="font-semibold">{comment.author}</p>
                  <p className="text-sm text-gray-600">{comment.content}</p>
                </div>
              </div>
            ))}
            <form onSubmit={(e) => {
              e.preventDefault();
              const input = e.currentTarget.elements.namedItem('comment');
              if (input.value.trim()) {
                onAddComment(post.id, input.value);
                input.value = '';
              }
            }} className="flex gap-2">
              <Input name="comment" placeholder="Add a comment..." className="flex-1" />
              <Button type="submit">Post</Button>
            </form>
          </div>
        </CardContent>
      )}
    </Card>
  );
};
export default Post;
