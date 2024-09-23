'use client';
import React, { useState } from "react";
import { Button } from "./ui/button";
import { Card, CardContent, CardHeader } from "./ui/card";
import { Input } from "./ui/input";
import dynamic from 'next/dynamic';
import 'react-quill/dist/quill.snow.css';
import 'monaco-editor/min/vs/editor/editor.main.css';
import '/app/globals.css'

const MonacoEditor = dynamic(() => import('@monaco-editor/react'), { ssr: false });
const ReactQuill = dynamic(() => import('react-quill'), { ssr: false });

export function CreatePost({ newPost, newPostCode, setNewPost, setNewPostCode, onPostSubmit, list_lang }) {
  const [title, setTitle] = useState('');
  const [showCodeEditor, setShowCodeEditor] = useState(false);
  const [lang, setLang] = useState('javascript');
  const [imageUrls, setImageUrls] = useState([""]); // Store image URLs

  const handle_lang = (e) => {
    setLang(e.target.value);
  };

  // Handle image upload to Cloudflare
  const handleImageUpload = async (event) => {
 
    const mockImages = ['https://images.unsplash.com/photo-1615525137689-198778541af6?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 'https://images.unsplash.com/photo-1615525137689-198778541af6?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'];
    setImageUrls(mockImages);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (title.trim() && newPost.trim()) {
      onPostSubmit({ title, content: newPost, code: newPostCode, lang, images: imageUrls });
      setTitle('');
      setNewPost('');
      setNewPostCode('');
      setImageUrls([]); // Clear image URLs after submission
      setImageUrls([]); // Clear image URLs after submission
    }
  };

  return (
    <Card>
      <CardHeader>
        <h2 className="text-lg font-semibold">Create a Post</h2>
        <h3 className="text-sm text-gray-500">Select Language</h3>
        <select onChange={handle_lang} className="mb-4 lang-list">
          {list_lang.map((lang) => (
            <option key={lang} value={lang}>{lang}</option>
          ))}
        </select>
      </CardHeader>
      <CardContent>
        <form onSubmit={handleSubmit}>
          <Input
            placeholder="Post Title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            className="mb-4"
          />
          <ReactQuill
            value={newPost}
            onChange={setNewPost}
            placeholder="What's on your mind?"
            className="mb-4"
          />

          <Button type="button" onClick={() => setShowCodeEditor(!showCodeEditor)} className="mb-4">
            {showCodeEditor ? 'Hide Code Snippet' : 'Add Code Snippet'}
          </Button>

          {showCodeEditor && (
            <MonacoEditor
              height="300px"
              width="100%"
              language={lang}
              value={newPostCode}
              onChange={setNewPostCode}
              options={{
                selectOnLineNumbers: true,
                automaticLayout: true,
              }}
              className="code-editor"
            />
          )}

          <Input type="file" accept="image/*" onChange={handleImageUpload} multiple className="input-file"/>
          
          {imageUrls.length > 0 && (
            <div className="image-preview">
              {imageUrls.map((url, index) => (
                <img key={index} src={url}/>
              ))}
            </div>
          )}
          
          <Button type="submit" className="mt-4" style={{ backgroundColor: 'green' }}>Post</Button>
        </form>
      </CardContent>
    </Card>
  );
}